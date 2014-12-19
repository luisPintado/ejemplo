using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MUSIC.MVVM.ViewModel;

namespace MUSIC.MVVM.Views
{
    /// <summary>
    /// Lógica de interacción para ViewPlayList.xaml
    /// </summary>
    public partial class ViewPlayList : Window
    {
        public ViewPlayList(int idSong)
        {
            InitializeComponent();
            ViewModelListSong oModel = (ViewModelListSong)this.grid.DataContext;
            oModel.IdSong = idSong;
            if (oModel.CloseAction == null)
                oModel.CloseAction = new Action(() => this.Close());
        }
    }
}
