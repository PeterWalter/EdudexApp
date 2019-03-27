using System;
using FileHelpers;

namespace edudex
{
    [IgnoreFirst(1)]
    [FixedLengthRecord(FixedMode.ExactLength)]
    public sealed class studentFTE
    {


        [FieldFixedLength(15)]
        private String mNational_Id;
        public String National_Id
        {
            get { return mNational_Id; }
            set { mNational_Id = value; }
        }


        [FieldFixedLength(20)]
        private String mAlternate_Id;
        public String Alternate_Id
        {
            get { return mAlternate_Id; }
            set { mAlternate_Id = value; }
        }


        [FieldFixedLength(3)]
        private String mAlternate_Id_type;
        public String Alternate_Id_type
        {
            get { return mAlternate_Id_type; }
            set { mAlternate_Id_type = value; }
        }


        [FieldFixedLength(20)]
        private String mQualification_Code;
        public String Qualification_Code
        {
            get { return mQualification_Code; }
            set { mQualification_Code = value; }
        }

        [FieldFixedLength(4)]
        private String mFTE_year;
        public String FTE_year
        {
            get { return mFTE_year; }
            set { mFTE_year = value; }
        }


        [FieldFixedLength(5)]
        private String mFTE;
        public String FTE
        {
            get { return mFTE; }
            set { mFTE = value; }
        }

        [FieldFixedLength(20)]
        private String mProvider_Code;
        public String Provider_Code
        {
            get { return mProvider_Code; }
            set { mProvider_Code = value; }
        }


        [FieldFixedLength(10)]
        private String mProvider_ETQA_Id;
        public String Provider_ETQA_Id
        {
            get { return mProvider_ETQA_Id; }
            set { mProvider_ETQA_Id = value; }
        }


        [FieldFixedLength(8)]
        private String mDate_Stamp;

        public String Date_Stamp
        {
            get { return mDate_Stamp; }
            set { mDate_Stamp = value; }
        }


    }
}
