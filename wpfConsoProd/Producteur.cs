using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wpfConsoProd
{
    public class Producteur : INotifyPropertyChanged
    {
        private string _Nom;

        public string Nom
        {
            get { return _Nom; }
            set {
                if (this._Nom != value)
                {
                    this._Nom = value;
                    this.NotifyPropertyChanged("Nom");
                }
            }
        }

        private bool _pause;

        public bool pause
        {
            get { return _pause; }
            set {
                if (this._pause != value)
                {
                    this._pause = value;
                    this.NotifyPropertyChanged("pause");
                }
            }
        }

        private BackgroundWorker _WorkerProd;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propname)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }

        public BackgroundWorker workerProd
        {
            get { return _WorkerProd; }
            set { _WorkerProd = value; }
        }

        public MainWindow mw { get; set; }

        public Producteur(string nom, MainWindow m)
        {
            Nom = nom;
            pause = false;
            mw = m;
            workerProd = new BackgroundWorker();
            workerProd.WorkerReportsProgress = true;
            workerProd.WorkerSupportsCancellation = true;

            workerProd.DoWork += WorkerProd_DoWork;
            workerProd.ProgressChanged += WorkerProd_ProgressChanged;
            workerProd.RunWorkerCompleted += WorkerProd_RunWorkerCompleted;
            
        }

        private void WorkerProd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }

        private void WorkerProd_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (mw.pipe.Value < 20)
            {
                mw.pipe.Value += e.ProgressPercentage;
            }
        }

        private void WorkerProd_DoWork(object sender, DoWorkEventArgs e)
        {
            while (!pause)
            {
                int i = 0;
                i++;
                workerProd.ReportProgress(i);
                Thread.Sleep(100);
            }
        }
    }
}
