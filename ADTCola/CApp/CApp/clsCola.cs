using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CApp
{
    public class clsCola
    {
        //Atributos
        public const int MAX = 10;//poner 100
        private int[] _cola;
        private int _front;//primero
        private int _rear;//ultimo
        //Constructor
        public clsCola()
        {
            _front = -1;
            _rear = -1;
            _cola = new int[MAX];
        }

        public clsCola(clsCola p)
        {
            _front = p._front;
            _rear = p._rear;
            _cola = new int[MAX];
            for (int i = 0; i < p._front; i++)
            {
                _cola[i] = p._cola[i];
            }
        }

        public int front
        {
            get { return _front; }
            set { _front = value; }
        }
        public int rear
        {
            get { return _rear; }
            set { _rear = value; }
        }
        public int[] cola
        {
            get { return _cola; }
            set { _cola = value; }
        }

        // Adiciona un elemento en la parte posterior de la Cola
        public void Add(int elemento)
        {
            if (!Llena())
            {
                rear++;
                cola[rear] = elemento;
            }
        }
        //Borra el elemento de la parte del frente de la Cola
        public void Delete()
        {
            if (!Vacia())
            {
                front++;
            }
        }
        // Valida si la Cola esta llena
        public bool Llena()
        {
            if (rear + 1 == MAX)
            {
                return true;
            }
            return false;
            // return rear + 1 == MAX;

        }
        // Valida si Cola esta Vacia
        public bool Vacia()
        {
            if (front == rear)
            {
                return true;
            }
            return false;
            //  return front == rear;
        }
        // Obtiene el Primer Elelemeto de la Cola
        public int Front()
        {
            if (!Vacia())
            {
                return cola[front + 1];
            }
            return 0;
        }
        // Obtiene el Ultimo Elemento de la Cola
        public int Rear()
        {
            if (!Vacia())
            {
                return cola[rear];
            }
            return 0;
        }
        //long (p) que calcule el numero de elementos de una cola.
        public int Long(){
          return (rear-front);  
        }

        public int Long2()
        {
            int contador = 0;
            for (int i = front+1; i <= rear; i++)
            {
                contador++;
            }
            return contador;
        }

        public int Long3( clsCola p)
        {
            int contador = 0;
            for (int i = p.front + 1; i <= p.rear; i++)
            {
                contador++;
            }
            return contador;
        }

        //descola(p, n) que elimine los primeros n elementos en una cola p si los hay
        public void descolar(clsCola p,int n)
        {
            if (Long3(p)>=n)
            {
                for (int i = 1; i <= n; i++)
                {
                    p.Delete();
                }
            }

        }

       /*duplica(p) que duplique una cola p de forma que cada elemento de p 
        aparezca dos veces seguidas conservando el mismo orden relativo que en p*/
       public clsCola duplica( clsCola p)
        {
            clsCola C = new clsCola();
            C = p;
            while (!p.Vacia())
            {
                C.Add(p.Front());
                p.Delete();
            }
            return C;
        }
        /*concatena(p, q) que genere la cola C resultante de unir los elementos de p 
         * y q desde el primero hacia el ultimo
         */
        public clsCola concatena(clsCola p,  clsCola q)
        {
            clsCola C = new clsCola(p);
            int cantidad = C.Long2() + q.Long2();
            if (cantidad <= MAX)
            {
                while (!q.Vacia())
                {
                    C.Add(q.Front());
                    q.Delete();
                }
            }
            return C;
        }
        //------------Otra Forma wendy
        public clsCola concatena2(clsCola p, clsCola q)
        {
            clsCola C = new clsCola();
            int fp = p.front + 1;
            int fq = q.front + 1;
            if (p.Vacia() != true)
            {
                while (fp <= p.rear)
                {
                    C.Add(p.cola[fp]); //ingresa todos los valores de P
                    fp++;
                }
            }
            if (q.Vacia() != true)
            {
                while (fq <= q.rear)
                {
                    C.Add(q.cola[fq]); //ingresa todos los valores de Q
                    fq++;
                }
            }
            return C;
        }
        /*mezcla(p, q) que genere la cola resultante de ir uniendo alternativamente 
         * los elementos de p y q desde sus respectivos primero hacia el ultimo*/
        public clsCola mezcla(clsCola p, clsCola q)
        {
            clsCola C = new clsCola();
            int cantidad = p.Long() + q.Long();
            if (cantidad <= MAX)
            {
                while (!p.Vacia() || !q.Vacia())
                {
                    if (!p.Vacia())
                    {
                        C.Add(p.Front());
                        p.Delete();
                    }
                    if (!q.Vacia())
                    {
                        C.Add(q.Front());
                        q.Delete();
                    }
                }
            }
            return C;
        }
        // credito Wendy Schoengut  otro nivel
        public clsCola mezcla2(clsCola p, clsCola q)
        {
            clsCola C = new clsCola();
            int fp = p.front + 1;
            int fq = q.front + 1;
            if (p.rear == q.rear || p.rear > q.rear)
            {
                while (fp < p.rear)
                {
                    C.Add(p.cola[fp]);
                    C.Add(q.cola[fq]);
                    fp++; fq++;
                }
            }
            else if (q.rear > p.rear)
            {
                while (fq < q.rear)
                {
                    C.Add(p.cola[fp]);
                    C.Add(q.cola[fq]);
                    fp++; fq++;
                }
            }
            return C;
        }

        //-------------Imprimir
        public string Imprimir()
        {
            string salida = " [";
            if (Vacia()!=true)
            {
                for (int i = this._front+1; i <=this._rear; i++)
                {
                    salida = salida + _cola[i].ToString() + "|";

                }

            }
            salida = salida.Substring(0, salida.Length-1);
            return salida+"]";
        } 










    }
}
