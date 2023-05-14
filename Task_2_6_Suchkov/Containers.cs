using System;

namespace container
{
    // Container classes
    public class Subject
    {
        public string subj;
        public string exam_date;
        public string t_name;
        public string t_surname;
        public string t_patronymic;
        public int mark;
    }

    public class Data
    {
        public int subj_size;
        public string name;
        public string surname;
        public string patronymic;
        public string date_of_birth;
        public Subject[] subjs;
    }
}