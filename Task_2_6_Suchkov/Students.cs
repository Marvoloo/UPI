using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using container;

namespace students
{
    public class Students
    {
        private Data[] students;
        private List<int> positions;
        private List<int> positions_1;
        public int size;
        private Students() { }
        public Students(string path)
        {
            int len = get_size_of_file(path);
            students = new Data[len];
            for (int i = 0; i < len; i++)
                students[i] = new Data();
            //MessageBox.Show(positions.Count.ToString());
            parse_file(path);
        }
        // Return count of studnets
        private int get_size_of_file(string path)
        {
            if (File.Exists(path))
            {

                string[] file = File.ReadAllLines(path);
                positions = new List<int>();
                //MessageBox.Show(file.Length.ToString());
                for (int i = 0; i < file.Length; i++)
                {
                    if (file[i] == "{")
                    {
                        positions.Add(i);
                        //MessageBox.Show(positions.Count.ToString());
                    }
                }
                positions.Add(file.Length);
                size = positions.Count - 1;
                return (size);
            }
            return 0;
        }
        // Parser
        private void parse_file(string path)
        {
            if (File.Exists(path))
            {
                string[] file = File.ReadAllLines(path);
                for (int i = 0; i < positions.Count - 1; i++)
                {
                    get_subject_len(positions[i], positions[i + 1], file);
                    // MessageBox.Show("Кол-во предметов:" + (positions_1.Count - 1).ToString());
                    students[i].name = file[positions[i] + 2];
                    students[i].surname = file[positions[i] + 1];
                    students[i].patronymic = file[positions[i] + 3];
                    students[i].date_of_birth = file[positions[i] + 4];
                    // MessageBox.Show(students[i].name +"\n"+ students[i].surname + "\n"+students[i].patronymic + "\n"+ students[i].date_of_birth + "\n");
                    parse_subj(students[i], file);
                }
                //MessageBox.Show(positions.Count.ToString());
            }
        }
        // Return count of student subjects
        private void get_subject_len(int start, int end, string[] file)
        {
            positions_1 = new List<int>();
            for (int i = start; i < end; i++)
            {
                if (file[i] == "[")
                {
                    positions_1.Add(i);
                    //MessageBox.Show(positions.Count.ToString());
                }
            }
            positions_1.Add(end - 1);
        }
        // Parser
        private void parse_subj(Data student, string[] file)
        {
            student.subjs = new Subject[positions_1.Count - 1];
            for (int j = 0; j < positions_1.Count - 1; j++)
                student.subjs[j] = new Subject();
            student.subj_size = positions_1.Count - 1;
            for (int i = 0; i < positions_1.Count - 1; i++)
            {
                student.subjs[i].subj = file[positions_1[i] + 1];
                student.subjs[i].exam_date = file[positions_1[i] + 2];
                student.subjs[i].t_name = file[positions_1[i] + 4];
                student.subjs[i].t_surname = file[positions_1[i] + 3];
                student.subjs[i].t_patronymic = file[positions_1[i] + 5];
                student.subjs[i].mark = int.Parse(file[positions_1[i] + 6]);
                //MessageBox.Show(student.subjs[i].subj + "\n" + student.subjs[i].exam_date + "\n" + student.subjs[i].t_name + "\n" + student.subjs[i].t_surname + "\n" +
                //student.subjs[i].t_patronymic + "\n" + student.subjs[i].mark + "\n");
            }
        }
        // Getter (DeepCopy)
        public Data[] get_students()
        {
            Data[] students_copy = new Data[size];
            for (int i = 0; i < size; i++)
            {
                students_copy[i] = new Data();
                students_copy[i].subj_size = students[i].subj_size;
                students_copy[i].name = students[i].name;
                students_copy[i].surname = students[i].surname;
                students_copy[i].patronymic = students[i].patronymic;
                students_copy[i].date_of_birth = students[i].date_of_birth;
                students_copy[i].subjs = new Subject[students_copy[i].subj_size];
                for (int j = 0; j < students_copy[i].subj_size; j ++)
                {
                    students_copy[i].subjs[j] = new Subject();
                    students_copy[i].subjs[j].subj = students[i].subjs[j].subj;
                    students_copy[i].subjs[j].exam_date = students[i].subjs[j].exam_date;
                    students_copy[i].subjs[j].t_name = students[i].subjs[j].t_name;
                    students_copy[i].subjs[j].t_surname = students[i].subjs[j].t_surname;
                    students_copy[i].subjs[j].t_patronymic = students[i].subjs[j].t_patronymic;
                    students_copy[i].subjs[j].mark = students[i].subjs[j].mark;
                }
            }
            return students_copy;
        }
    }
}