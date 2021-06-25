using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class MainForm : Form
    {
        List<Question> questions = new List<Question>();
        private Random rnd = new Random();
        int level = 0;
        Question currentQuestion;

        public MainForm()
        {
            InitializeComponent();
            DBConnect();
            //ReadFile();
            startGame();
        }
        private void DBConnect()
        {
            SQLiteConnection cn = new SQLiteConnection(@"Data Source=C:\Users\User\Desktop\Lab8\SQLiteDatabaseBrowserPortable\wwtbam.db");
            cn.Open();
            var cmd = new SQLiteCommand("select * from Вопросы", cn);
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string[] line = { dr["Вопрос"].ToString(), dr["Ответ1"].ToString(),
                    dr["Ответ2"].ToString(),dr["Ответ3"].ToString(),dr["Ответ4"].ToString(),
                    dr["ПОтвет"].ToString(), dr["Сложность"].ToString() };
                questions.Add(new Question(line));
            }
            dr.Close();
            cn.Close();
        }
        private void ReadFile()
        {
            string path = @"Вопросы.txt";

            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    questions.Add(new Question(line.Split('\t')));
                }
            }
        }
        private void ShowQuestion(Question q)
        {
            label1.Text = q.Text;
            button1.Text = q.Answers[0];
            button2.Text = q.Answers[1];
            button3.Text = q.Answers[2];
            button4.Text = q.Answers[3];
        }
        private Question GetQuestion(int level)
        {
            var questionsWithLevel = questions.Where(q => q.Level == level).ToList();
            return questionsWithLevel[rnd.Next(questionsWithLevel.Count)];
        }
        private void NextStep()
        {
            Button[] btns = new Button[] { button1, button2,
                button3, button4 };

            foreach (Button btn in btns)
                btn.Enabled = true;

            level++;
            currentQuestion = GetQuestion(level);
            ShowQuestion(currentQuestion);
            listBox1.SelectedIndex = listBox1.Items.Count - level;
        }
        private void startGame()
        {
            level = 0;
            NextStep();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                NextStep();
            else
            {
                MessageBox.Show("Неверный ответ!");
                startGame();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                NextStep();
            else
            {
                MessageBox.Show("Неверный ответ!");
                startGame();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                NextStep();
            else
            {
                MessageBox.Show("Неверный ответ!");
                startGame();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (currentQuestion.RightAnswer == int.Parse(button.Tag.ToString()))
                NextStep();
            else
            {
                MessageBox.Show("Неверный ответ!");
                startGame();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button[] btns = new Button[] { button1, button2,
                button3, button4 };

            int count = 0;
            while (count < 2)
            {
                int n = rnd.Next(4);
                int answer = int.Parse(btns[n].Tag.ToString());

                if (answer != currentQuestion.RightAnswer && btns[n].Enabled)
                {
                    btns[n].Enabled = false;
                    count++;
                }
            }
        }
    }
}