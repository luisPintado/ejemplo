using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using MUSIC.MVVM.Helpers;

namespace MUSIC.MVVM.ViewModel
{
    public class ViewModelListSong : ViewModelBase
    {

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
            }
        }
        private int _idSong;
        public int IdSong
        {
            get
            {
                return _idSong;
            }
            set
            {
                if (_idSong == value) return;
                _idSong = value;
                NotifyPropertyChanged("IdSong");
            }
        }

     
        private ICommand _SubmitCommand;
        ReferenceServiceSong.SongServiceClient  oService = null;

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value) return;
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public ViewModelListSong()
        {
            _listsong = new ENTITIES.ListSong();
            oService = new ReferenceServiceSong.SongServiceClient();
            _listSongs = new ObservableCollection<ENTITIES.ListSong>(oService.GetLists());
            _listSongs.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChanged);
        }


        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(Submit);
                }
                return _SubmitCommand;
            }
        }

       

        private void Submit()
        {
            if (Name != string.Empty && SelectListSong != null && Name != null)
            {
                ENTITIES.ListSong oListSong = oService.AddList(new ENTITIES.ListSong()
                { 
                    Create = DateTime.Now,
                    Name = this.Name
                });
                if (oListSong.Id != 0)
                {
                    ENTITIES.PlayList oPlayList = oService.AddPlayList(new ENTITIES.PlayList()
                    {
                        DateCreation = DateTime.Now,
                        List = oListSong,
                        Song = new ENTITIES.Song() { IdSong = this.IdSong }
                    }); 


                    CurrentListsSongs.Add(oListSong);
                    SelectListSong = oListSong;
                    MessageBox.Show("Exito");
                    CloseAction();
                    
                }
            }
            else
            {
               ENTITIES.PlayList oPlayList= oService.AddPlayList(new ENTITIES.PlayList()
                { 
                     DateCreation = DateTime.Now,
                     List =SelectListSong,
                     Song = new ENTITIES.Song() { IdSong = this.IdSong }
                }); 
                if(oPlayList.Id != 0)
                {
                    MessageBox.Show("Exito");
                    CloseAction();
                }
            }
        }


      

        void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged("CurrentListsSongs");
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



    }
}
