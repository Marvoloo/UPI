using System.Data;
using System.IO;
using System.Windows.Forms;
using container;
using students;

namespace Task_2_6_Suchkov
{
    public partial class Form1 : Form
    {
        // Path to file with students
        private string path = String.Empty;

        private Rectangle grid1_original_rectangle;
        private Rectangle grid2_original_rectangle;
        private Rectangle button_original_rectangle;
        private Rectangle textbox_original_rectangle;
        private Rectangle form_original_rectangle;

        public Form1()
        {
            InitializeComponent();
        }

        private void readb_Click(object sender, EventArgs e)
        {
            path = Path_box.Text;
            if (String.IsNullOrEmpty(path))
                path = "./Data.txt";
            if (file_checker(path) == 0)
            {
                MessageBox.Show("Ошибка строения файла!\n");
                return;
            }
            Students st = new Students(path);
            Data[] students = st.get_students();
            printTable_first(students, st.size);
            printTable_second(students, st.size);
        }
        private int students_checker(string[] file, int index)
        {
            int counter = 0;
            for (int i = index + 1; i < file.Length; i++)
            {
                if (file[i] == "[")
                    break;
                counter++;
            }
            if (counter == 4)
                return (1);
            return (0);
        }
        private int subject_checker(string[] file, int index)
        {
            int counter = 0;
            for (int i = index + 1; i < file.Length; i++)
            {
                if (file[i] == "]")
                    break;
                counter++;
            }
            if (counter == 6)
                return (1);
            return (0);
        }
        private int file_checker(string path)
        {
            int counter_11 = 0;
            int counter_12 = 0;
            int counter_21 = 0;
            int counter_22 = 0;
            int subj_counter = 0;
            string[] file = File.ReadAllLines(path);
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] == "{")
                {
                    subj_counter = 0;
                    counter_11++;
                    if (students_checker(file, i) == 0)
                        return (0);
                }
                if (file[i] == "}")
                {
                    if (subj_counter < 3 || subj_counter > 5)
                        return (0);
                    counter_12++;
                }
                if (file[i] == "[")
                {
                    subj_counter++;
                    counter_21++;
                    if (subject_checker(file, i) == 0)
                        return (0);
                }
                if (file[i] == "]")
                    counter_22++;
            }
            if (counter_11 != counter_12 || counter_21 != counter_22)
                return (0);
            return (1);
        }
        private void print_Rows(DataTable dt, Data[] students, int i)
        {
            int mark_2 = 0;
            int mark_3 = 0;
            int mark_4 = 0;
            int mark_5 = 0;

            for (int j = 0; j < students[i].subj_size; j++)
            {
                if (students[i].subjs[j].mark == 2)
                    mark_2++;
                if (students[i].subjs[j].mark == 3)
                    mark_3++;
                if (students[i].subjs[j].mark == 4)
                    mark_4++;
                if (students[i].subjs[j].mark == 5)
                    mark_5++;

            }
            dt.Rows.Add(i, students[i].surname, students[i].name, students[i].patronymic, students[i].date_of_birth, mark_5, mark_4, mark_3, mark_2);
        }
        private void print_Fall_Students(DataTable dt, Data[] students, int i)
        {
            int mark_2 = 0;

            for (int j = 0; j < students[i].subj_size; j++)
            {
                if (students[i].subjs[j].mark == 2)
                    mark_2++;
            }
            if (mark_2 != 0)
                dt.Rows.Add(i, students[i].surname, students[i].name, students[i].patronymic, mark_2);
        }
        private void printTable_first(Data[] students, int size)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Имя");
            dt.Columns.Add("Отчество");
            dt.Columns.Add("Дата рождения");
            dt.Columns.Add("Число оценок отлично");
            dt.Columns.Add("Число оценок хорошо");
            dt.Columns.Add("Число оценок удовлетвортельно");
            dt.Columns.Add("Число оценок не удовлитворительно");
            for (int i = 0; i < size; i++)
                print_Rows(dt, students, i);
            //dt.Rows.Add(i, "text" + i);
            Students_table.DataSource = dt;
        }
        private void printTable_second(Data[] students, int size)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Фамилия");
            dt.Columns.Add("Имя");
            dt.Columns.Add("Отчество");
            dt.Columns.Add("Число оценок не удовлитворительно");
            for (int i = 0; i < size; i++)
                print_Fall_Students(dt, students, i);
            //dt.Rows.Add(i, "text" + i);
            Fallstudents_table.DataSource = dt;
        }
        // Resizing
        private void Form1_Load(object sender, EventArgs e)
        {
            form_original_rectangle = new Rectangle(this.Location.X, this.Location.Y, this.Size.Width, this.Size.Height);
            grid1_original_rectangle = new Rectangle(Students_table.Location.X, Students_table.Location.Y, Students_table.Size.Width, Students_table.Size.Height);
            grid2_original_rectangle = new Rectangle(Fallstudents_table.Location.X, Fallstudents_table.Location.Y, Fallstudents_table.Size.Width, Fallstudents_table.Size.Height);
            button_original_rectangle = new Rectangle(readb.Location.X, readb.Location.Y, readb.Size.Width, readb.Size.Height);
            textbox_original_rectangle = new Rectangle(Path_box.Location.X, Path_box.Location.Y, Path_box.Size.Width, Path_box.Size.Height);
        }
        private void resize(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(form_original_rectangle.Width);
            float yRatio = (float)(this.Height) / (float)(form_original_rectangle.Height);

            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            resize(grid1_original_rectangle, Students_table);
            resize(grid2_original_rectangle, Fallstudents_table);
            resize(button_original_rectangle, readb);
            resize(textbox_original_rectangle, Path_box);
        }
    }
}