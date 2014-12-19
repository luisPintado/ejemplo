using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using MUSIC.MVVM.Helpers;

namespace MUSIC.MVVM.ViewModel
{
    public class ViewModelSong : ViewModelBase
    {
        private string _textSeach;
        public string TextSearch
        {
            get
            {
                return _textSeach;
            }
            set
            {
                if (_textSeach == value)
                    return;

                _textSeach = value;
                NotifyPropertyChanged("TextSearch");
            }
        }

      
     

        private ENTITIES.TypesSeach _selectedEnumTypeSearch;
        public ENTITIES.TypesSeach SelectedEnumTypeSearch
        {
            get { return _selectedEnumTypeSearch; }
            set
            {
                _selectedEnumTypeSearch = value;
                NotifyPropertyChanged("SelectedEnumTypeSearch");
            }
        }


        public IEnumerable<ENTITIES.TypesSeach> ListEnumTypeSearch
        {
            get
            {
                return Enum.GetValues(typeof(ENTITIES.TypesSeach))
                    .Cast<ENTITIES.TypesSeach>();
            }
        }


        public string Name
        {
            get { return _song.Album.Genre.Description; }
            set
            {
                if (value == _song.Album.Genre.Description)
                    return;
                _song.Album.Genre.Description = value;
                NotifyPropertyChanged("Name");
            }
        }

        private ObservableCollection<ENTITIES.Song> _songs;

        private ICommand _AddListCommand, _SearchCommand;
        private ReferenceServiceSong.SongServiceClient oServicio = null;

        public ViewModelSong()
        {
            _song = new ENTITIES.Song();
            oServicio = new ReferenceServiceSong.SongServiceClient();
            _songs = new ObservableCollection<ENTITIES.Song>(oServicio.GetCompleteSongs());
            _songs.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(_songs_CollectionChanged);

            SetConfigurationView();

            _listsong = new ENTITIES.ListSong();
            _listSongs = new ObservableCollection<ENTITIES.ListSong>(oServicio.GetLists());
            _listSongs.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChanged);

           
        }

        void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("CurrentListsSongs");
        }

        void _songs_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("CurrentSongs");
        }

        private ENTITIES.Song _song;
        public ENTITIES.Song CurrentSong
        {
            get
            {
                return _song;
            }
            set
            {
                if (_song == value)
                    return;
                _song = value;
                NotifyPropertyChanged("CurrentSong");
            }
        }

        public ObservableCollection<ENTITIES.Song> CurrentSongs
        {
            get
            {
                return _songs;
            }
            set
            {
                if (_songs == value)
                    return;
                _songs = value;
                NotifyPropertyChanged("CurrentSongs");
            }
        }

        public ICommand AddListCommand
        {
            get
            {
                if (_AddListCommand == null)
                {
                    _AddListCommand = new RelayCommand(AddList);
                }
                return _AddListCommand;
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new RelayCommand(Search);
                }
                return _SearchCommand;
            }
        }

        private void AddList()
        {
            if (CurrentSong != null)
            {
                Views.ViewPlayList windowsAgregarLista = new Views.ViewPlayList(CurrentSong.IdSong);
                windowsAgregarLista.ShowDialog();
                ENTITIES.ListSong Result = windowsAgregarLista.combo.Items[windowsAgregarLista.combo.Items.Count - 1] as ENTITIES.ListSong;
                CurrentListsSongs.Add(Result);
            }
        }

        private void Search()
        {
            CurrentSongs.Clear();
            CurrentSongs = new ObservableCollection<ENTITIES.Song>(oServicio.GetCompleteSongs());
            switch (SelectedEnumTypeSearch)
            {
                case MUSIC.ENTITIES.TypesSeach.Titulo:
                    if (TextSearch != string.Empty)
                        CurrentSongs = new ObservableCollection<ENTITIES.Song>(CurrentSongs.Where(source => source.Source.ToUpper().Contains(TextSearch.ToUpper())).ToList<ENTITIES.Song>());
                    break;
                case MUSIC.ENTITIES.TypesSeach.Autor:
                    if (TextSearch != string.Empty)
                        CurrentSongs = new ObservableCollection<ENTITIES.Song>(CurrentSongs.Where(source => source.Autor.ToUpper().Contains(TextSearch.ToUpper())).ToList<ENTITIES.Song>());
                    break;
                case MUSIC.ENTITIES.TypesSeach.Album:
                    if (TextSearch != string.Empty)
                        CurrentSongs = new ObservableCollection<ENTITIES.Song>(CurrentSongs.Where(source => source.Album.Name.ToUpper().Contains(TextSearch.ToUpper())).ToList<ENTITIES.Song>());
                    break;
                case MUSIC.ENTITIES.TypesSeach.Todos:
                    TextSearch = string.Empty;
                    CurrentSongs = new ObservableCollection<ENTITIES.Song>(oServicio.GetCompleteSongs());
                    break;
            }
            SetConfigurationView();
        }


        private ObservableCollection<ENTITIES.ListSong> _listSongs;
        public ObservableCollection<ENTITIES.ListSong> CurrentListsSongs
        {
            get
            {
                return _listSongs;
            }
            set
            {
                if (_listSongs == value) return;
                _listSongs = value;
                NotifyPropertyChanged("CurrentListSongs");
            }
        }


        private ENTITIES.ListSong _listsong;
        public ENTITIES.ListSong SelectListSong
        {
            get
            {
                return _listsong;
            }
            set
            {
                if (_listsong == value) return;
                _listsong = value;
                NotifyPropertyChanged("SelectListSong");
                GetSongFromList();
            }
        }


        private void GetSongFromList()
        {
            CurrentSongs.Clear();
            CurrentSongs = new ObservableCollection<ENTITIES.Song>((oServicio.GetSongsByList(SelectListSong).ToList<ENTITIES.Song>()));
            SetConfigurationView();
        }

        private void SetConfigurationView()
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(CurrentSongs);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Album.Genre.Description");
            view.GroupDescriptions.Add(groupDescription);
        }

    }
}
