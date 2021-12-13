using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseTestProject.Model
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200)]
        public string QuestionBody { get; set; }

        public Question()
        {

        }

        public Question(string questionBody)
        {
            this.QuestionBody = questionBody;
        }
    }
}
