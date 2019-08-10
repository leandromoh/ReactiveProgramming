using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ReactiveProgramming
{
    public class Aluno : INotifyPropertyChanged
    {
        private string nome;
        public string Nome
        {
            get { return nome; }
            set
            {
                if (nome != value)
                {
                    nome = value;
                    RaisePropertyChanged("Nome");
                }
            }
        }
        private int nota;
        public int Nota
        {
            get { return nota; }
            set
            {
                if (nota != value)
                {
                    nota = value;
                    RaisePropertyChanged("Nota");
                }
            }
        }
        public Aluno(string nome, int nota)
        {
            Nome = nome;
            Nota = nota;
        }
        public void AlterarNota()
        {
            Nota++;
        }

        //-- implementação da interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public static void Main()
        {
            Aluno aluno = new Aluno("Macoratti", 7);
            aluno.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                Console.WriteLine(string.Format("Propriedade {0} foi alterada", e.PropertyName));
            };

            aluno.Nome = "Jose Carlos Macoratti";
            aluno.AlterarNota();
            aluno.Nota = 6;
        }
    }
}

