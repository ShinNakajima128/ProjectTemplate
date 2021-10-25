using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace MasterData
{
    [Serializable]
    public class FourChoicesQuiz
    {
        public int PeriodsID;
        public string Question;
        public string Choices1;
        public string Choices2;
        public string Choices3;
        public string Choices4;
        public string Answer;
    }

    public class QuizMasterDataClass<T>
    {
        public string Version;
        public T[] Data;
    }
}
