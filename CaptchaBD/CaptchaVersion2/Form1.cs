using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CaptchaVersion2
{
    public partial class Form1 : Form
    {
        //Equipo
        //Medina Díaz Eduardo
        //Contreras Acosta Cesar
        //Ortiz Hernández Rocío Guadalupe
        //Juárez Devora Jesús Antonio
        //Rodríguez Vásquez Gerardo
        //Martínez Rodríguez Francisco Alfonso

        //Se crea una conexion a mysql

        MySqlConnection Cnn = new MySqlConnection();
        //Declaramos una instancia de objeto random
        Random r = new Random();
        //Declaramos un auxiliar para el texto de la caja de texto
        string aux1 = "";
        string auxnombre = "", direccion = "";
        //Declaramos una variable para la posicion
        int posicion = 0;
        //Sonidos para si el texto es correcto o incorrecto
        //Declaramos una instancia de objeto tipo SoundPlayer
        SoundPlayer simpleSound = new SoundPlayer(@"Goods.wav");
        SoundPlayer simpleSoundRed = new SoundPlayer(@"Mals.wav");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            final();
         
        }

        private void final()
        {
            txtCaja.Text = "";
            posicion = 0;
            this.BackColor = Color.FromArgb(224, 224, 224);
            posicion = r.Next(1, 6);
            try
            {
                //Guardamos la direccion de conexion en una conexion string
                Cnn.ConnectionString = "Server = localhost; Database = eventos; User Id = root; Password = hola; ";
                //Abrimos conexion
                Cnn.Open();
                //Generamos una intancia de objeto de tipo comando Mysql la cual contiene la consulta
                MySqlCommand myCmd = new MySqlCommand("select * from pictures where Id='" + posicion + "'");
                //Para que el comando busque la dirreccion
                myCmd.Connection = Cnn;
                //Se crea una instancia de objeto la cual almane el comando para ejecutarlo y regresar un valor
                //El data reader recupera datos 
                // El executereader ejecuta el comando y regresa un valor (te regrasa el numero de columnas afectadas)
                MySqlDataReader myReaader = myCmd.ExecuteReader();
                //Lee toda la tabla
                while (myReaader.Read())
                {
                    //Sigue leyendo la tabla
                    myReaader.Read();
                    //Busca una la columna la convierte en string y la almacena en una variable
                    auxnombre = myReaader["nombre"].ToString();
                    //La ruta le cambiamos la direccion de las diagonales y le ponemos dos en vez de uno
                    direccion = myReaader["imagen"].ToString();
                }
                /* Teniendo la direccion, decimos que el pictureBox1 busque la locacion de la imagen
                Ya que la variable direccion tiene la direccion donde esta la imagen
                Y con el ImageLocation se busca esa direccion */
                pictureBox1.ImageLocation = direccion;
                //Cerramos conexion
                Cnn.Close();
            }
            catch (MySqlException er)
            {
                MessageBox.Show("You have an error " + er);
            }
        }

        private void done()
        {
            aux1 = "";
            simpleSound.Load();
            simpleSoundRed.Load();
            aux1 = txtCaja.Text;
            if (aux1.Equals(auxnombre) && posicion == 1)
            {
                simpleSound.Play();
                this.BackColor = Color.Green;
                txtCaja.Text = "";
                MessageBox.Show("Felicidades es correcto!!", "Human", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                final();
            }

            else if (aux1.Equals(auxnombre) && posicion == 2)
            {
                simpleSound.Play();
                this.BackColor = Color.Green;
                txtCaja.Text = "";
                MessageBox.Show("Felicidades es correcto!!", "Human", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                final();
            }
            else if (aux1.Equals(auxnombre) && posicion == 3)
            {
                simpleSound.Play();
                this.BackColor = Color.Green;
                txtCaja.Text = "";
                MessageBox.Show("Felicidades es correcto!!", "Human", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                final();
            }
            else if (aux1.Equals(auxnombre) && posicion == 4)
            {
                simpleSound.Play();
                this.BackColor = Color.Green;
                txtCaja.Text = "";
                MessageBox.Show("Felicidades es correcto!!", "Human", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                final();
            }
            else if (aux1.Equals(auxnombre) && posicion == 5 || posicion == 6)
            {
                simpleSound.Play();
                this.BackColor = Color.Green;
                txtCaja.Text = "";
                MessageBox.Show("Felicidades es correcto!!", "Human", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                final();
            }
            else
            {
                simpleSoundRed.Play();
                this.BackColor = Color.Red;
                MessageBox.Show("You are a machine!!", "MACHINE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                final();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                done();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            final();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            done();
        }
    }
}