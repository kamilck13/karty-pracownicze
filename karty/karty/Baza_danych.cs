using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace karty
{
    class Baza_danych
    {
        static string server = "91.214.0.196";
        static string bazaDanych = "sop";
        static string UID = "sop_user";
        static string haslo = "kwa@fvtCZF12jgq";

        public Baza_danych()
        {

        }
        public static void WyslijDoBazy(string sql)
        {
            string mojePolaczenie = "SERVER=" + server + "; DATABASE=" + bazaDanych + "; UID=" + UID + "; password=" + haslo + "; charset=utf8;";

            MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
            try
            {
                polaczenie.Open();

                MySqlCommand cmdSel = new MySqlCommand(sql, polaczenie);
                cmdSel.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Błąd logowania do bazy danych MySql", "Błąd");
            }
            polaczenie.Close();
        } //laczy z bazą danych i wykonuje zadanie bez zwracania wyniku
        public static void ZaladujDaneBazy(string nazwatabeli, string parametry, DataGridView tabela)
        {
            switch (nazwatabeli)
            { 
                case "pracownicy":
                    {
                        string sql = "Select *";

                        sql += " FROM pracownicy " + parametry;
                        AkcjaNaBazie(sql, "pracownicy", tabela);
                        break;
                    }
                case "karty":
                    {
                        string sql = "Select *";

                        sql += " FROM czas_pracy " + parametry;
                        AkcjaNaBazie(sql, "karty", tabela);
                        break;

                    }

            }

        }//laduje wybrana baze z ewentualną modyfikacją danych
        public static void AkcjaNaBazie(string sql, string nazwatabeli, DataGridView tabela)
        {
            string mojePolaczenie = "SERVER=" + server + "; DATABASE=" + bazaDanych + "; UID=" + UID + "; password=" + haslo + "; charset=utf8;";

            MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
            try
            {
                polaczenie.Open();

                using (MySqlCommand cmdSel = new MySqlCommand(sql, polaczenie))
                {


                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                    da.Fill(dt);
                    switch (nazwatabeli)
                    {
                        case "pracownicy":
                            {
                                tabela.DataSource = dt.DefaultView;
                                break;
                            }
                        case "karty":
                            {
                                tabela.DataSource = dt.DefaultView;
                                break;
                            }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Błąd logowania do bazy danych MySql", "Błąd");
            }
            polaczenie.Close();
        } //laczy z bazą danych i wykonuje zadanie na tabelach DataGridView
        public static string PobierzZBazy(string sql)//pobiera komórkę z bazy i zwraca sting
        {
            string mojePolaczenie = "SERVER=" + server + "; DATABASE=" + bazaDanych + "; UID=" + UID + "; password=" + haslo + "; charset=utf8;";

            MySqlConnection polaczenie = new MySqlConnection(mojePolaczenie);
            try
            {
                polaczenie.Open();

                using (MySqlCommand cmdSel = new MySqlCommand(sql, polaczenie))
                {


                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                    da.Fill(dt);

                    // kData.Value = Convert.ToDateTime(cmdSel.ExecuteScalar());
                    string zwrot = Convert.ToString(cmdSel.ExecuteScalar());
                    polaczenie.Close();
                    return zwrot;

                }
            }
            catch
            {
                MessageBox.Show("Błąd logowania do bazy danych MySql", "Błąd");
                return null;
            }


        }
    }
}
