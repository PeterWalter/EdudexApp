using System;
using FileHelpers;

namespace edudex
{
    [IgnoreFirst(1)]
    [FixedLengthRecord(FixedMode.ExactLength)]
    public sealed class staffEmployment
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


        [FieldFixedLength(5)]
        private String mStaff_Category_Id;
        public String Staff_Category_Id
        {
            get { return mStaff_Category_Id; }
            set { mStaff_Category_Id = value; }
        }

        [FieldFixedLength(20)]
        private String mFiller;
        public String Filler_01
        {
            get { return mFiller; }
            set { mFiller = value; }
        }

        [FieldFixedLength(10)]
        private String mStaa_Category_ETQA_id;
        public String Staff_Category_Etqa_id
        {
            get { return mStaa_Category_ETQA_id; }
            set { mStaa_Category_ETQA_id = value; }
        }

        [FieldFixedLength(8)]
        private String mAppointment_Date;
        public String Appointment_Date
        {
            get { return mAppointment_Date; }
            set { mAppointment_Date = value; }
        }

        [FieldFixedLength(8)]
        private String mTermination_Date;
        public String Termination_Date
        {
            get { return mTermination_Date; }
            set { mTermination_Date = value; }
        }

        [FieldFixedLength(10)]
        private String mEmployment_Status_Id;
        public String Employment_Status_Id
        {
            get { return mEmployment_Status_Id; }
            set { mEmployment_Status_Id = value; }
        }

        [FieldFixedLength(20)]
        private String mFiller_02;
        public String Filler_02
        {
            get { return mFiller_02; }
            set { mFiller_02 = value; }
        }

        [FieldFixedLength(20)]
        private String mProvider_Code;
        public String Provider_Code
        {
            get { return mProvider_Code; }
            set { mProvider_Code = value; }
        }

        [FieldFixedLength(10)]
        private String mProvider_ETQA_ID;
        public String Provider_ETQA_ID
        {
            get { return mProvider_ETQA_ID; }
            set { mProvider_ETQA_ID = value; }
        }

        [FieldFixedLength(15)]
        private String mHIghest_Qualification_Type_Id;
        public String HIghest_Qualification_Type_Id
        {
            get { return mHIghest_Qualification_Type_Id; }
            set { mHIghest_Qualification_Type_Id = value; }
        }

        [FieldFixedLength(10)]
        private String mAppointment_Type_Id;
        public String Appointment_Type_Id
        {
            get { return mAppointment_Type_Id; }
            set { mAppointment_Type_Id = value; }
        }

        [FieldFixedLength(5)]
        private String mFTE;
        public String FTE
        {
            get { return mFTE; }
            set { mFTE = value; }
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
