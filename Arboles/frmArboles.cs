using Arboles.Model;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arboles
{
    public partial class frmArboles : Form
    {

        ArbolBinario arbolBinario;

        public frmArboles()
        {
            InitializeComponent();
            //arbolBinario = new ArbolBinario("A", "B", new object[] { "D", "E" }, "C", new object[] { "F", "G" });
            arbolBinario = new ArbolBinario("RaizInicial", new Profesor[] { new Profesor("A"), new Profesor("B") });
        }
        private void RecorridoPreOrden(Nodo pNodo)
        {
            if (pNodo != null)
            {
                this.txtPreOrden.AppendText(pNodo.Profesor.Nombre + " - ");
                this.RecorridoPreOrden(pNodo.Izq);
                this.RecorridoPreOrden(pNodo.Der);
            }
        }

        private void RecorridoInOrden(Nodo pNodo)
        {
            if (pNodo != null)
            {
                RecorridoInOrden(pNodo.Izq);
                this.txtInOrden.AppendText(pNodo.Profesor.Nombre + " - ");
                RecorridoInOrden(pNodo.Der);
            }
        }

        private void RecorridoAmplitud(List<Nodo> pNodo, int nivel)
        {
            if (pNodo.Count > 0)
            {
                List<Nodo> Lista = new List<Nodo>();
                this.txtAmplitud.Text += "Nivel " + nivel.ToString() + ": ";

                foreach (Nodo N in pNodo)
                {
                    this.txtAmplitud.Text += N.Profesor.Nombre + "-";
                    if (N.Izq != null || N.Der != null)
                    {
                        Lista.Add(N.Izq);
                        Lista.Add(N.Der);
                    }
                }
                nivel++;
                this.RecorridoAmplitud(Lista, nivel);
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            // Limpiar el contenido actual de txtPreOrden
            this.txtPreOrden.Clear();

            // Realizar el recorrido preorden y almacenar el resultado en txtPreOrden
             RecorridoPreOrden(arbolBinario.Raiz);

            // Obtener la longitud actual del texto en txtPreOrden
            int currentLength = this.txtPreOrden.Text.Length;

            // Verificar si la longitud es mayor que 2 antes de intentar extraer la subcadena
            if (currentLength > 2)
            {
                // Extraer la subcadena desde el inicio hasta el penúltimo carácter
                this.txtPreOrden.Text = this.txtPreOrden.Text.Substring(0, currentLength - 2);
            }
            else
            {
                // Opcional: Decidir qué hacer si la longitud es menor o igual a 2
                // Por ejemplo, podrías dejar el texto tal cual o eliminar todos los caracteres
                this.txtPreOrden.Text = "";
            }

            // Continuar con otras acciones, como actualizar la interfaz de usuario
            this.TreeView3.Nodes.Clear();
            this.MostrarTreeView(arbolBinario.Raiz, null, this.TreeView3);
            this.TreeView3.ExpandAll();
        }


        private void MostrarTreeView(Nodo pNodo, TreeNode pTreeNode, TreeView pTreeView)
        {
            if (pNodo != null)
            {
                TreeNode NodoTemp = new TreeNode(pNodo.Profesor.Nombre);
                if (pTreeNode == null)
                {
                    pTreeView.Nodes.Add(NodoTemp);
                }
                else
                {
                    pTreeNode.Nodes.Add(NodoTemp);
                }
                this.MostrarTreeView(pNodo.Der, NodoTemp, pTreeView);
                this.MostrarTreeView(pNodo.Izq, NodoTemp, pTreeView);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.trvNro1.Nodes.Clear();
            TreeNode AA = new TreeNode("A");
            TreeNode BB = new TreeNode("B");
            TreeNode CC = new TreeNode("C");
            TreeNode DD = new TreeNode("D");
            TreeNode EE = new TreeNode("E");
            TreeNode FF = new TreeNode("F");
            TreeNode GG = new TreeNode("G");
            TreeNode HH = new TreeNode("H");

            if (AA.Nodes.Count < 2)//VERIFICAR EN FUNCIÓN DE LA CANTIDAD DE NODOS "HIJOS" QUE NO PUEDA SUPERAR "NUNCA" MÁS DE 2 (BINARIO)
            {
                AA.Nodes.Add(CC);
                AA.Nodes.Add(BB);
            }

            //A
            //   C
            //   B

            BB.Nodes.Add(EE);
            BB.Nodes.Add(DD);

            //A
            //   C
            //   B
            //      E
            //      D


            CC.Nodes.Add(GG);
            CC.Nodes.Add(FF);

            //A
            //   C
            //      G
            //      F
            //   B
            //      E
            //      D

            if (this.trvNro1.Nodes.Count == 0)
                this.trvNro1.Nodes.Add(AA);

            AA.ExpandAll();
        }

        private void TodosElementos(TreeNodeCollection nodo)
        {
            foreach (var item in nodo)
            {
                if ((item as TreeNode).Nodes.Count > 0)
                {
                    //Recursiva... 
                    TodosElementos((item as TreeNode).Nodes);
                }

                MessageBox.Show(((item as TreeNode).Text));
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Captura el nombre ingresado
            string nombreIngresado = Interaction.InputBox("Ingrese Nombre");

            // Crea un nuevo nodo basado en el nombre ingresado
            Nodo nuevoNodo = new Nodo(new Profesor(nombreIngresado));

            if (arbolBinario.Raiz == null)
            {
                arbolBinario.Raiz = nuevoNodo;
            }
            else
            {
         
                arbolBinario.Raiz.Izq = nuevoNodo;
            }

            if (this.TreeView2.SelectedNode != null)
            {
                //this.TreeView2.SelectedNode.Nodes.Count -> Con esta propiedad sé cuántos nodos tengo de "hijos"

                //Agrego un nuevo elemento
                this.TreeView2.SelectedNode.Nodes.Add(new TreeNode(nombreIngresado));
            }
            else
            {
                //Validar que solo pueda tener un elemento RAIZ
                this.TreeView2.Nodes.Add(new TreeNode(nombreIngresado));
            }

         

            this.TreeView2.ExpandAll();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (this.TreeView2.SelectedNode != null)
            {
                this.TreeView2.SelectedNode.Remove();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            // Limpiar el contenido actual de txtInOrden
            this.txtInOrden.Clear();

            // Realizar el recorrido en orden y almacenar el resultado en txtInOrden
            RecorridoInOrden(arbolBinario.Raiz);

            // Obtener la longitud actual del texto en txtInOrden
            int currentLength = this.txtInOrden.Text.Length;

            // Verificar si la longitud es mayor que 2 antes de intentar extraer la subcadena
            if (currentLength > 2)
            {
                // Extraer la subcadena desde el inicio hasta el penúltimo carácter
                this.txtInOrden.Text = this.txtInOrden.Text.Substring(0, currentLength - 2);
            }
            else
            {
                // Opcional: Decidir qué hacer si la longitud es menor o igual a 2
                this.txtInOrden.Text = "";
            }

            // Continuar con otras acciones, como actualizar la interfaz de usuario
            this.TreeView3.Nodes.Clear();
            this.MostrarTreeView(arbolBinario.Raiz, null, this.TreeView3);
            this.TreeView3.ExpandAll();
        }




        private void Button7_Click(object sender, EventArgs e)
        {
            this.txtAmplitud.Clear();
            this.RecorridoAmplitud(new List<Nodo>() { arbolBinario.Raiz }, 1);
            this.txtAmplitud.Text = this.txtAmplitud.Text.Substring(0, this.txtAmplitud.TextLength - 1);
            this.TreeView6.Nodes.Clear();
            this.MostrarTreeView(arbolBinario.Raiz, null, this.TreeView6);
            this.TreeView6.ExpandAll();
        }

        private void frmArboles_Load(object sender, EventArgs e)
        {

        }

        private void TreeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //MessageBox.Show(this.TreeView2.SelectedNode.Text);
        }

        private void TreeView4_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
