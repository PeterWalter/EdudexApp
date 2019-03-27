using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Renci.SshNet;
using FileHelpers;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Controls;
using System.Reflection;
using edudex;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace EdudexApp
{
    public partial class Form1 : SfForm

    {
        private string personal_file = "";
        private string qualification_enrolment_file = "";
        private string student_fte_file = "";
        private string staff_employment_file = "";
        private string readfile;
        private int n = 0;
        private string selectedFile;
        private string selectedDate; // The logged processed date of Edudex files in Database

        public static List<personInformation> personInfo = new List<personInformation>();
        public static List<qualificationEnrolment> qualifications = new List<qualificationEnrolment>();
        public static List<staffEmployment> staff = new List<staffEmployment>();
        public static List<studentFTE> ftes = new List<studentFTE>();
        public static List<personInformation> DB_personInfo = new List<personInformation>();
        public static List<qualificationEnrolment> DB_qualifications = new List<qualificationEnrolment>();
        public static List<staffEmployment> DB_staff = new List<staffEmployment>();
        public static List<studentFTE> DB_ftes = new List<studentFTE>();
        public static List<string> submissions = new List<string>();

        // ssh connection settings-------------------------------------
        public SshClient sshClient;
        static string host = "192.168.0.19";      //ENTER SERVER HOST
        static string user = "sacapuser";             //ENTER USER
        static int sshport = 22;
        // Console.Write("Password: ");      //ENTER SERVER PASSWORD
        static string passwd = "nMnTFBWR59mJ";
        // --------------------------------------------------------------
        public PasswordConnectionInfo connectionInfo = new PasswordConnectionInfo(host, sshport, user, passwd);
        public string connectionString = ConfigurationManager.ConnectionStrings["MySql"].ConnectionString;
        //public IDbConnection db = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public BindingSource bindingSource = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            // save_edudex_files();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            groupBox4.Visible = false;
            folderBrowserDialog1.SelectedPath = Properties.Settings.Default.edudexOut;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Openfile();
        }

        private void Openfile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Filter = "dat Files|*.dat| Text files|*.txt|All Files|*.*";
                readfile = openFileDialog1.FileName;
                openFileDialog1.RestoreDirectory = true;
                folderBrowserDialog1.SelectedPath = openFileDialog1.InitialDirectory;
                fileToLoad(readfile);
            }
        }

        private void fileToLoad(string readfile)
        {
            string path = readfile;
            string[] names = Path.GetFileNameWithoutExtension(path).Split('-');
            string loadedFile = Path.GetFileNameWithoutExtension(path);
            string file_type = names[1].Substring(0, 4);
            textBox1.Text = names[1].Substring(4);
            switch (file_type)
            {
                case "6661":
                    var engine = new FileHelperEngine<personInformation>();
                    engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
                    personInformation[] res = engine.ReadFile(path);
                    var result = res.ToList();
                    personInfo = result;
                    label3.Text = "Personal Information";
                    listBox1.Items.Add(loadedFile);
                    bindingSource.DataSource = result;
                    dataGridView1.DataSource = bindingSource;
                    break;

                case "6663":
                    var engine2 = new FileHelperEngine<qualificationEnrolment>();
                    engine2.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
                    qualificationEnrolment[] res2 = engine2.ReadFile(path);
                    listBox1.Items.Add(loadedFile);
                    var result1 = res2.ToList();
                    qualifications = result1;
                    bindingSource.DataSource = result1;
                    dataGridView1.DataSource = bindingSource;
                    label3.Text = "Qualifications and Enrolment data";
                    break;

                case "6665":
                    var engine1 = new FileHelperEngine<staffEmployment>();
                    engine1.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
                    staffEmployment[] res1 = engine1.ReadFile(path);
                    listBox1.Items.Add(loadedFile);
                    label3.Text = "Staff Employment";
                    var result2 = res1.ToList();
                    staff = result2;
                    bindingSource.DataSource = result2;
                    dataGridView1.DataSource = bindingSource;
                    break;

                case "6668":
                    var engine3 = new FileHelperEngine<studentFTE>();
                    engine3.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
                    studentFTE[] res3 = engine3.ReadFile(path);
                    listBox1.Items.Add(loadedFile);
                    label3.Text = "Student FTE Data";
                    var result3 = res3.ToList();
                    ftes = result3;
                    bindingSource.DataSource = result3;
                    dataGridView1.DataSource = bindingSource;

                    //  dataGridView1.Invalidate();
                    break;
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Openfile();
            button2.Visible = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {


            if (n == 0)
            {
                start_Connection();
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"assets\ConnectFilled_16x_32.bmp");
                this.toolStripButton1.Image = Image.FromFile(path);
                n = 1;
                button1.Visible = true;
            }
            else
            {
                SshConnection_close();
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"assets\ConnectFilled_grey_16x_32.bmp");
                this.toolStripButton1.Image = Image.FromFile(path);
                // SshClient.Disconnect();
                n = 0;
                button1.Visible = false;
            }

        }
        private async void save_edudex_files()
        {
            // 1. Read the last logged file of procesed data

            using (var connection = new MySqlConnection(connectionString))
            {
                if (n == 1)
                {
                    await connection.OpenAsync();
                }
                else
                {
                    label2.Text = "SSH ports not opened, SQL connection not possible until port connection is done";
                }

            }

        }

        private void load_edudex_files()
        {
            // 1. Create the database tables if not exists
            // 2. Load the data to the tables
            //3. process the data using stored procedure


        }
        public void SshConnection_close()
        {

            if (sshClient.IsConnected)
            {
                sshClient.Disconnect();
                label1.Text = "ssh disconnected";
                sshClient.Dispose();
            }
            else
            {
                label1.Text = "connection was never available";
            }

        }
        public void start_Connection()
        {
            sshClient = new SshClient(connectionInfo);

            sshClient.Connect();
            if (sshClient.IsConnected)
            {
                uint sqlPort = 3306;
                var portFwd = new ForwardedPortLocal("127.0.0.1", sqlPort, "localhost", sqlPort);
                sshClient.AddForwardedPort(portFwd);
                portFwd.Start();
                label1.Text = "SSH connection successful";
                if (portFwd.IsStarted)
                {
                    // toolStripButton1.Image = @("./assets/Connect_greenOverlay_16x32.bmp");
                    label1.Text = "Port Forwarding has started";
                }
                else
                {
                    label1.Text = "Port Forwarding has failed";
                    sshClient.Disconnect();
                    sshClient.Dispose();
                }
                button2.Visible = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sshClient.IsConnected)
            {
                sshClient.Disconnect();
                sshClient.Dispose();
            }

            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string myDate = textBox1.Text.ToString().Trim();
            if (myDate.Length == 6)
            {
                if (n == 1)
                {
                    //var qp = new DynamicParameters();
                    //qp.Add("@p1", myDate);
                    try
                    {
                        using (var connection = new MySqlConnection(connectionString))
                        {

                            connection.Open();
                            connection.Execute("edudex_create_submission_tables", new { the_date = myDate }, commandType: CommandType.StoredProcedure);
                            connection.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                        //connection.Close();
                    }

                    button1.Visible = false;

                }
                else
                {
                    MessageBox.Show("Need ssh Connection!!");
                }
            }
            else
            {
                MessageBox.Show("Wrong Date values !! Please correct");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            if (selectedFile == null)
            {
                MessageBox.Show("NO file selected");
            }
            else
            {
                if (n == 1)
                {
                    button3.Visible = true;
                    string this_file = selectedFile.Substring(5);
                    string table_name = "";
                    string file_type = this_file.Substring(0, 4);
                    switch (file_type)
                    {
                        case "6661":
                            table_name = "personal_info" + "_" + this_file;
                            break;
                        case "6663":
                            table_name = "qualification_enrolment" + "_" + this_file;
                            break;
                        case "6665":
                            table_name = "staff_employment" + "_" + this_file;
                            break;
                        case "6668":
                            table_name = "student_fte" + "_" + this_file;
                            break;
                    }
                    var sql = "SELECT * FROM " + table_name;
                    var sql1 = "DELETE FROM " + table_name;
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        //1. check to see if table exists in database and if it has records
                        var amount = connection.Query(sql);

                        if (amount.Count() > 0)
                        {
                            var affectedRows = connection.Execute(sql1);
                        }
                        switch (file_type)
                        {
                            case "6661":
                                foreach (personInformation a in personInfo)
                                {
                                    string sql2 = "INSERT INTO " + table_name + " (national_id, alternative_id, alternative_id_type, equity_code, nationality_code, home_language_code, gender_code," +
                                            "citizen_residence_status_code, socioeconomic_status_code, disability_status_code, last_name, first_name, middle_name, title, birth_date, home_address_1," +
                                            "home_address_2, home_address_3, postal_address_1, postal_address_2, postal_address_3, home_address_postal_code, postal_addr_postal_code, person_phone_number," +
                                            "cellphone_number, fax_number, email_address, province_code, provider_code, provider_etqa_id, previous_lastname, previous_alternative_id, previous_alternative_id_type," +
                                            "previous_provider_code, previous_provider_etqa_id, seeing_rating_id, hearing_rating_id, communication_rating_id, walking_rating_id, remembering_rating_id, selfcare_rating_id, date_stamp) " +
                                            "VALUES (@id, @alt_id, @id_type, @equity, @n_code, @language, @gender, @citizen, @socio, @disability, @surname, @name, @middle, @title, @dob, @ha1, @ha2, @ha3, @pa1, @pa2, @pa3, @hapc," +
                                            "@papc, @phone, @cell, @fax, @email, @province, @provider, @provider_etqa, @p_lastname, @p_alt_id, @p_id_type, @p_prov_code, @p_petqa_id, @see, @hear, @comm, @walk, @rem, @self, @stamp);";

                                    MySqlCommand cmd = new MySqlCommand(sql2, connection);
                                    cmd.Prepare();
                                    cmd.Parameters.AddWithValue("@id", a.National_id);
                                    cmd.Parameters.AddWithValue("@alt_id", a.Alternative_id);
                                    cmd.Parameters.AddWithValue("@id_type", a.Alternative_Id_Type);
                                    cmd.Parameters.AddWithValue("@equity", a.Equity_Code);
                                    cmd.Parameters.AddWithValue("@n_code", a.Nationality_Code);
                                    cmd.Parameters.AddWithValue("@language", a.Home_Language_Code);
                                    cmd.Parameters.AddWithValue("@gender", a.Gender_Code);
                                    cmd.Parameters.AddWithValue("@citizen", a.Citizen_Residence_Status_Code);
                                    cmd.Parameters.AddWithValue("@socio", a.Socioeconomic_Status_Code);
                                    cmd.Parameters.AddWithValue("@disability", a.Disability_Status_Code);
                                    cmd.Parameters.AddWithValue("@surname", a.Last_Name);
                                    cmd.Parameters.AddWithValue("@name", a.First_Name);
                                    cmd.Parameters.AddWithValue("@middle", a.Middle_Name);
                                    cmd.Parameters.AddWithValue("@title", a.Title);
                                    cmd.Parameters.AddWithValue("@dob", a.Birth_Date);
                                    cmd.Parameters.AddWithValue("@ha1", a.Home_Address_1);
                                    cmd.Parameters.AddWithValue("@ha2", a.Home_Address_2);
                                    cmd.Parameters.AddWithValue("@ha3", a.Home_Address_3);
                                    cmd.Parameters.AddWithValue("@pa1", a.Postal_Address_1);
                                    cmd.Parameters.AddWithValue("@pa2", a.Postal_Address_2);
                                    cmd.Parameters.AddWithValue("@pa3", a.Postal_Address_3);
                                    cmd.Parameters.AddWithValue("@hapc", a.Home_Address_Postal_Code);
                                    cmd.Parameters.AddWithValue("@papc", a.Postal_Addr_Postal_Code);
                                    cmd.Parameters.AddWithValue("@phone", a.Person_phone_number);
                                    cmd.Parameters.AddWithValue("@cell", a.Cellphone_number);
                                    cmd.Parameters.AddWithValue("@fax", a.Fax_number);
                                    cmd.Parameters.AddWithValue("@email", a.email_address);
                                    cmd.Parameters.AddWithValue("@province", a.Province_Code);
                                    cmd.Parameters.AddWithValue("@provider", a.Provider_Code);
                                    cmd.Parameters.AddWithValue("@provider_etqa", a.provider_etqa_id);
                                    cmd.Parameters.AddWithValue("@p_lastname", a.Previous_Lastname);
                                    cmd.Parameters.AddWithValue("@p_alt_id", a.Previous_Alternative_Id);
                                    cmd.Parameters.AddWithValue("@p_id_type", a.Previous_Alternative_Id_Type);
                                    cmd.Parameters.AddWithValue("@p_prov_code", a.Previous_Provider_code);
                                    cmd.Parameters.AddWithValue("@p_petqa_id", a.Previous_Provider_Etqa_Id);
                                    cmd.Parameters.AddWithValue("@see", a.Seeing_Rating_Id);
                                    cmd.Parameters.AddWithValue("@hear", a.Hearing_Rating_Id);
                                    cmd.Parameters.AddWithValue("@comm", a.Communication_Rating_Id);
                                    cmd.Parameters.AddWithValue("@walk", a.Walking_Rating_Id);
                                    cmd.Parameters.AddWithValue("@rem", a.Remembering_Rating_Id);
                                    cmd.Parameters.AddWithValue("@self", a.Selfcare_Rating_Id);
                                    cmd.Parameters.AddWithValue("@stamp", a.Date_Stamp);

                                    cmd.ExecuteNonQuery();
                                }

                                break;
                            case "6663":
                                foreach (qualificationEnrolment a in qualifications)
                                {

                                    string sql3 = "INSERT INTO " + table_name + " (national_id, alternative_id,alternative_id_type,qualification_code, learner_achievement_status_id,learner_achievement_type_id, learner_achievement_date," +
                                        "learner_enrolled_date, honours_classification, part_of, learnership_code, provider_code, provider_etqa_id, assessor_etqa_id, cesm1, cesm2," +
                                        "most_recent_enrolment_date, date_stamp) " +
                                        "VALUES (@id,@alt_id,@id_type,@qualification,@achieve_status, @achieve_id, @achieve_date,@enroll_date,@h_classification,@part_of,@learner_code,@p_code," +
                                        "@p_etqa_id, @assessor_id,@cesm1,@cesm2,@recent_enrol_date,@stamp);";

                                    MySqlCommand cmd = new MySqlCommand(sql3, connection);
                                    cmd.Prepare();
                                    cmd.Parameters.AddWithValue("@id", a.National_Id);
                                    cmd.Parameters.AddWithValue("@alt_id", a.Alternative_Id);
                                    cmd.Parameters.AddWithValue("@id_type", a.Alternative_Id_type);
                                    cmd.Parameters.AddWithValue("@qualification", a.Qualification_Code);
                                    cmd.Parameters.AddWithValue("@achieve_status", a.Learner_Achievement_status_Id);
                                    cmd.Parameters.AddWithValue("@achieve_id", a.Learner_Achievement_Type_Id);
                                    cmd.Parameters.AddWithValue("@achieve_date", a.Learner_Achievement_Date);
                                    cmd.Parameters.AddWithValue("@enroll_date", a.Learner_enrolled_Date);
                                    cmd.Parameters.AddWithValue("@h_classification", a.Honours_Classification);
                                    cmd.Parameters.AddWithValue("@part_of", a.Part_of);
                                    cmd.Parameters.AddWithValue("@learner_code", a.Learnership_code);
                                    cmd.Parameters.AddWithValue("@p_code", a.Provider_Code);
                                    cmd.Parameters.AddWithValue("@p_etqa_id", a.Provider_Etqa_Id);
                                    cmd.Parameters.AddWithValue("@assessor_id", a.Assessor_Etqa_Id);
                                    cmd.Parameters.AddWithValue("@cesm1", a.CESM1);
                                    cmd.Parameters.AddWithValue("@cesm2", a.CESM2);
                                    cmd.Parameters.AddWithValue("@recent_enrol_date", a.Most_Recent_Enrolment_Date);
                                    cmd.Parameters.AddWithValue("@stamp", a.Date_Stamp);
                                    //cmd.Parameters.AddWithValue("@rcm_id", a.);

                                    cmd.ExecuteNonQuery();
                                }
                                break;
                            case "6665":
                                foreach (staffEmployment a in staff)
                                {

                                    string sql4 = "INSERT INTO " + table_name + " (national_id, alternative_id, alternative_id_type, staff_category_id, filler_01, staff_category_etqa_id, appointment_date, termination_date," +
                                        "employment_status_id, filler_02, provider_code, provider_etqa_id, highest_qualification_type_id, appointment_type_id, fte, date_stamp) " +
                                        "VALUES (@id, @alt_id, @id_type, @staff_cat, @filler, @s_cat_id, @appoint_date, @termination_date, @emp_status, @filler2, @p_code, @p_etqa_id, @h_q_type_id, @appoint_type, @fte, @stamp);";

                                    MySqlCommand cmd = new MySqlCommand(sql4, connection);
                                    cmd.Prepare();
                                    cmd.Parameters.AddWithValue("@id", a.National_Id);
                                    cmd.Parameters.AddWithValue("@alt_id", a.Alternative_Id);
                                    cmd.Parameters.AddWithValue("@id_type", a.Alternative_Id_type);
                                    cmd.Parameters.AddWithValue("@staff_cat", a.Staff_Category_Id);
                                    cmd.Parameters.AddWithValue("@filler", a.Filler_01);
                                    cmd.Parameters.AddWithValue("@s_cat_id", a.Staff_Category_Etqa_id);
                                    cmd.Parameters.AddWithValue("@appoint_date", a.Appointment_Date);
                                    cmd.Parameters.AddWithValue("@termination_date", a.Termination_Date);
                                    cmd.Parameters.AddWithValue("@emp_status", a.Employment_Status_Id);
                                    cmd.Parameters.AddWithValue("@filler2", a.Filler_02);
                                    cmd.Parameters.AddWithValue("@p_code", a.Provider_Code);
                                    cmd.Parameters.AddWithValue("@p_etqa_id", a.Provider_ETQA_ID);
                                    cmd.Parameters.AddWithValue("@h_q_type_id", a.HIghest_Qualification_Type_Id);
                                    cmd.Parameters.AddWithValue("@appoint_type", a.Appointment_Type_Id);
                                    cmd.Parameters.AddWithValue("@fte", a.FTE);
                                    cmd.Parameters.AddWithValue("@stamp", a.Date_Stamp);
                                    cmd.ExecuteNonQuery();
                                }
                                break;
                            case "6668":
                                foreach (studentFTE a in ftes)
                                {

                                    string sql5 = "INSERT INTO " + table_name + " (national_id, alternate_id, alternate_id_type, qualification_code, fte_year, fte, provider_code, provider_etqa_id, date_stamp) " +
                                        "VALUES (@id, @alt_id, @id_type, @q_code, @fte_yr, @fte, @p_code, @p_etqa_id, @stamp);";

                                    MySqlCommand cmd = new MySqlCommand(sql5, connection);
                                    cmd.Prepare();
                                    cmd.Parameters.AddWithValue("@id", a.National_Id);
                                    cmd.Parameters.AddWithValue("@alt_id", a.Alternate_Id);
                                    cmd.Parameters.AddWithValue("@id_type", a.Alternate_Id_type);
                                    cmd.Parameters.AddWithValue("@q_code", a.Qualification_Code);
                                    cmd.Parameters.AddWithValue("@fte_yr", a.FTE_year);
                                    cmd.Parameters.AddWithValue("@fte", a.FTE);
                                    cmd.Parameters.AddWithValue("@p_code", a.Provider_Code);
                                    cmd.Parameters.AddWithValue("@p_etqa_id", a.Provider_ETQA_Id);
                                    cmd.Parameters.AddWithValue("@stamp", a.Date_Stamp);
                                    cmd.ExecuteNonQuery();
                                }
                                break;
                        }



                        connection.Close();
                    }
                }
                else
                {
                    MessageBox.Show("There is no SSH connection!!!");
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (n == 1)
            {

                string this_file = selectedFile.Substring(5);
                //var sql = "SELECT TABLE_NAME FROM information_schema.tables WHERE TABLE_NAME LIKE %"+ this_file +"%";
                using (var connection = new MySqlConnection(connectionString))
                {
                    // 1. run stored procedure to process data
                    connection.Open();
                    connection.Execute("edudex_update_data", commandType: CommandType.StoredProcedure);

                    // 2. Load list of processed_data_logs into combobox
                    // var allsubmissions = connection.Query(sql);
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("No ssh connection!!");
            }
            label2.Text = "Data in tables processed";

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedFile = listBox1.SelectedItem.ToString();
            string file_type = selectedFile.Substring(5, 4);
            switch (file_type)
            {
                case "6661":
                    label3.Text = "Personal Information";
                    bindingSource.DataSource = personInfo;
                    dataGridView1.DataSource = bindingSource;
                    break;
                case "6663":
                    label3.Text = "Qualifications and Enrolment data";
                    bindingSource.DataSource = qualifications;
                    dataGridView1.DataSource = bindingSource;
                    break;

                case "6665":
                    label3.Text = "Staff Employment";
                    bindingSource.DataSource = staff;
                    dataGridView1.DataSource = bindingSource;
                    break;

                case "6668":
                    label3.Text = "Student FTE Data";
                    bindingSource.DataSource = ftes;
                    dataGridView1.DataSource = bindingSource;
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string Rec_file = "CHED-666";
            string db_filename = "";
            string path;
            string fullname;
            string fileHeader;

            if (string.IsNullOrEmpty(selectedDate))
            {
                MessageBox.Show("Please select 'Submission Date' from database records!!");
            }
            else
            {
                //1. get folder path to write files
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    path = folderBrowserDialog1.SelectedPath;
                    Properties.Settings.Default.edudexOut = path;
                    Properties.Settings.Default.Save();
                    string date = selectedDate.Substring(2);
                    //2. Read table data into collections
                    var sql = "SELECT national_id, alternative_id, alternative_id_type, equity_code, nationality_code, home_language_code, " +
                        "gender_code, citizen_residence_status_code, socioeconomic_status_code, disability_status_code, last_name, first_name, " +
                        "middle_name, title, birth_date, home_address_1, home_address_2,home_address_3, postal_address_1, postal_address_2, " +
                        "postal_address_3, home_address_postal_code, postal_addr_postal_code, person_phone_number, cellphone_number, fax_number, email_address, " +
                        "province_code, provider_code, provider_etqa_id, previous_lastname, previous_alternative_id, previous_alternative_id_type, previous_provider_code, " +
                        "previous_provider_etqa_id, seeing_rating_id, hearing_rating_id, communication_rating_id, walking_rating_id, remembering_rating_id, " +
                        "selfcare_rating_id, date_stamp FROM personal_info_6661" + date;                   
                    
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        //1. check to see if table exists in database and if it has records
                        DB_personInfo = connection.Query<personInformation>(sql).ToList();

                        connection.Close();
                    }
                    //3. write info to files
                    fullname = Rec_file + "1" + date + ".dat";
                    db_filename = Path.Combine(path, fullname);
                    var engine = new FileHelperEngine<personInformation>();
                    fileHeader = "HEADER621 PERSON INFORMATION  " + DB_personInfo.Count.ToString();
                    engine.HeaderText = fileHeader.PadRight(40);
                    engine.WriteFile(db_filename, DB_personInfo);
                    listBox2.Items.Add(fullname);
                    this.Invalidate();

                    var sql1 = "SELECT national_id, alternative_id, alternative_id_type, qualification_code, learner_achievement_status_id, assessor_registration_number, " +
                       "learner_achievement_type_id, learner_achievement_date, learner_enrolled_date, honours_classification, part_of, learnership_code, provider_code, " +
                       "provider_etqa_id, assessor_etqa_id, cesm1, cesm2, most_recent_enrolment_date, date_stamp FROM qualification_enrolment_6663" + date;

                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        //1. check to see if table exists in database and if it has records

                        DB_qualifications = connection.Query<qualificationEnrolment>(sql1).ToList();

                        connection.Close();
                    }
                    fullname = Rec_file + "3" + date + ".dat";
                    db_filename = Path.Combine(path, fullname);
                    var engine1 = new FileHelperEngine<qualificationEnrolment>();
                    fileHeader = "HEADER621 QUALIFICATION ENROL " + DB_qualifications.Count.ToString();
                    engine1.HeaderText = fileHeader.PadRight(40);
                    engine1.WriteFile(db_filename, DB_qualifications);
                    listBox2.Items.Add(fullname);


                    var sql2 = "SELECT national_id, alternative_id, alternative_id_type, staff_category_id, filler_01, staff_category_etqa_id, appointment_date, " +
                        "termination_date, employment_status_id, filler_02, provider_code, provider_etqa_id, highest_qualification_type_id, appointment_type_id, " +
                        "fte, date_stamp FROM staff_employment_6665" + date;

                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        //1. check to see if table exists in database and if it has records

                        DB_staff = connection.Query<staffEmployment>(sql2).ToList();

                        connection.Close();
                    }

                    fullname = Rec_file + "5" + date + ".dat";
                    db_filename = Path.Combine(path, fullname);
                    var engine2 = new FileHelperEngine<staffEmployment>();
                    fileHeader = "HEADER621 STAFF EMPLOYMENT " + DB_personInfo.Count.ToString();
                    engine2.HeaderText = fileHeader.PadRight(40);
                    engine2.WriteFile(db_filename, DB_staff);
                    listBox2.Items.Add(fullname);

                    //------------------------------------------------------------------------------------------------------
                    var sql3 = "SELECT national_id, alternate_id, alternate_id_type, qualification_code, fte_year, fte, provider_code, provider_etqa_id, date_stamp " +
                        "FROM student_fte_6668" + date;

                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        //1. check to see if table exists in database and if it has records
                        //var fromDB = connection.Query(sql3).ToList();
                        DB_ftes = connection.Query<studentFTE>(sql3).ToList();
                        connection.Close();
                    }

                    fullname = Rec_file + "8" + date + ".dat";
                    db_filename = Path.Combine(path, fullname);
                    var engine3 = new FileHelperEngine<studentFTE>();
                    fileHeader = "HEADER621 STUDENT FTE  " + DB_personInfo.Count.ToString();
                    engine3.HeaderText = fileHeader.PadRight(40);
                    engine3.WriteFile(db_filename, DB_ftes);
                    listBox2.Items.Add(fullname);
                }
            }
        }
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                selectedDate = comboBox1.Text;
            }

            private void toolStripButton2_Click(object sender, EventArgs e)
            {
                if (n == 1)
                {
                    var sql = "SELECT submissionDate FROM  processed_data_logs";
                    using (var connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        //1. check to see if table exists in database and if it has records
                        var records = connection.Query<string>(sql).ToList();
                        foreach (var a in records)
                        {
                            comboBox1.Items.Add(a);
                        }
                        //submissions = records.ToList();
                        connection.Close();
                    }
                    groupBox4.Visible = true;

                }
                else
                {
                    MessageBox.Show("There is no SSH connection!!");
                }
            

            }
        
    }
}
