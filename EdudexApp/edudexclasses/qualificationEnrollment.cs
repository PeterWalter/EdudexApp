using System;
using FileHelpers;

namespace edudex
{
    [IgnoreFirst(1)]
    [FixedLengthRecord(FixedMode.ExactLength)]
    public sealed class qualificationEnrolment
    {

        [FieldFixedLength(15)]
        private String mNational_Id;
        public String National_Id
        {
            get { return mNational_Id; }
            set { mNational_Id = value; }
        }


        [FieldFixedLength(20)]
        private String mAlternative_Id;
        public String Alternative_Id
        {
            get { return mAlternative_Id; }
            set { mAlternative_Id = value; }
        }


        [FieldFixedLength(3)]
        private String mAlternative_Id_type;
        public String Alternative_Id_type
        {
            get { return mAlternative_Id_type; }
            set { mAlternative_Id_type = value; }
        }


        [FieldFixedLength(20)]
        private String mQualification_Code;
        public String Qualification_Code
        {
            get { return mQualification_Code; }
            set { mQualification_Code = value; }
        }


        [FieldFixedLength(3)]
        private String mLearner_Achievement_status_Id;
        public String Learner_Achievement_status_Id
        {
            get { return mLearner_Achievement_status_Id; }
            set { mLearner_Achievement_status_Id = value; }
        }


        [FieldFixedLength(20)]
        private String mAssessor_Registration_Number;
        public String Assessor_Registration_Number
        {
            get { return mAssessor_Registration_Number; }
            set { mAssessor_Registration_Number = value; }
        }


        [FieldFixedLength(3)]
        private String mLearner_Achievement_Type_Id;
        public String Learner_Achievement_Type_Id
        {
            get { return mLearner_Achievement_Type_Id; }
            set { mLearner_Achievement_Type_Id = value; }
        }


        [FieldFixedLength(8)]
        private String mLearner_Achievement_Date;
        public String Learner_Achievement_Date
        {
            get { return mLearner_Achievement_Date; }
            set { mLearner_Achievement_Date = value; }
        }


        [FieldFixedLength(8)]
        private String mLearner_enrolled_Date;
        public String Learner_enrolled_Date
        {
            get { return mLearner_enrolled_Date; }
            set { mLearner_enrolled_Date = value; }
        }


        [FieldFixedLength(3)]
        private String mHonours_Classification;
        public String Honours_Classification
        {
            get { return mHonours_Classification; }
            set { mHonours_Classification = value; }
        }


        [FieldFixedLength(2)]
        private String mPart_of;
        public String Part_of
        {
            get { return mPart_of; }
            set { mPart_of = value; }
        }


        [FieldFixedLength(20)]
        private String mLearnership_code;
        public String Learnership_code
        {
            get { return mLearnership_code; }
            set { mLearnership_code = value; }
        }


        [FieldFixedLength(20)]
        private String mProvider_Code;
        public String Provider_Code
        {
            get { return mProvider_Code; }
            set { mProvider_Code = value; }
        }


        [FieldFixedLength(10)]
        private String mProvider_Etqa_Id;
        public String Provider_Etqa_Id
        {
            get { return mProvider_Etqa_Id; }
            set { mProvider_Etqa_Id = value; }
        }


        [FieldFixedLength(10)]
        private String mAssessor_Etqa_Id;
        public String Assessor_Etqa_Id
        {
            get { return mAssessor_Etqa_Id; }
            set { mAssessor_Etqa_Id = value; }
        }


        [FieldFixedLength(10)]
        private String mCESM1;
        public String CESM1
        {
            get { return mCESM1; }
            set { mCESM1 = value; }
        }


        [FieldFixedLength(10)]
        private String mCESM2;

        public String CESM2
        {
            get { return mCESM2; }
            set { mCESM2 = value; }
        }


        [FieldFixedLength(8)]
        private String mMost_Recent_Enrolment_Date;
        public String Most_Recent_Enrolment_Date
        {
            get { return mMost_Recent_Enrolment_Date; }
            set { mMost_Recent_Enrolment_Date = value; }
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
