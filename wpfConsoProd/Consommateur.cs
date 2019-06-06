using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace wpfConsoProd
{
    public class Consommateur : INotifyPropertyChanged
    {
        public MainWindow mw { get; set; }
        private string _Nom;
        private bool _pause;
        private BackgroundWorker _WorkerConso;

        public Consommateur(string nom, MainWindow m)
        {
            Nom = nom;
            pause = false;
            mw = m;


            workerConso = new BackgroundWorker();
            workerConso.WorkerReportsProgress = true;
            workerConso.WorkerSupportsCancellation = true;


            workerConso.DoWork += WorkerConso_DoWork;
            workerConso.ProgressChanged += WorkerConso_ProgressChanged;
            workerConso.RunWorkerCompleted += WorkerConso_RunWorkerCompleted;
        }

        private void WorkerConso_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void WorkerConso_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (mw.pipe.Value >= 0)
            {
                mw.pipe.Value -= e.ProgressPercentage;
            }
        }

        private void WorkerConso_DoWork(object sender, DoWorkEventArgs e)
        {
            while (pause == false)
            {
                int i = 0;
                i++;
                workerConso.ReportProgress(i);
                Thread.Sleep(50);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public bool pause
        {
            get { return _pause; }
            set
            {
                if (this._pause != value)
                {
                    this._pause = value;
                    this.NotifyPropertyChanged("pause");
                }
            }
        }

        public BackgroundWorker workerConso
        {
            get { return _WorkerConso; }
            set { _WorkerConso = value; }
        }

        public void NotifyPropertyChanged(string propname)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }
        
        
        
        

        
        

        

        

        
    }
}
