using FutebolModelBiblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace InterfaceGrafica
{
    /// <summary>
    /// Interaction logic for WindowGerenciamentoTimes.xaml
    /// </summary>
    public partial class WindowGerenciamentoTimes : Window, 
        INotifyPropertyChanged
    {

        private Time _Time = new Time();
        public Time TimeSelecionado
        {
            get
            {
                return _Time;
            }
            set
            {
                _Time = value;
                this.NotifyPropertyChanged("TimeSelecionado");
            }
        }

        public Boolean ModoCriacaoTime { get; set; } = false;

        public Visibility VisibilidadeDataGrid
        {
            get
            {
                if (ModoCriacaoTime)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }


        public IList<Time> Times { get; set; }

        public WindowGerenciamentoTimes()
        {
            InitializeComponent();

            this.DataContext = this;

            FacadeTimes facade = new FacadeTimes();
            this.Times = facade.ObterTimes();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string Property)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(
                    Property));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ModelFutebol ctx = new ModelFutebol();
            if (ModoCriacaoTime)
            {                
                ctx.Times.Add(TimeSelecionado);
                ctx.SaveChanges();
            }else
            {
                if (TimeSelecionado != null 
                    && TimeSelecionado.Id > 0)
                {
                    Time ParaSalvar = ctx.Times.Find(TimeSelecionado.Id);
                    ParaSalvar.Nome = TimeSelecionado.Nome;
                    ParaSalvar.DataFundacao = TimeSelecionado.DataFundacao;
                    ctx.Entry(ParaSalvar).State = 
                        System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
