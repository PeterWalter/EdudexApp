using System;
using FileHelpers;

namespace edudex
{
    [IgnoreFirst(1)]
    [FixedLengthRecord(FixedMode.ExactLength)]
    public sealed class personInformation
    {

        [FieldFixedLength(15)]
        private String mNational_id;
        public String National_id
        {
            get { return mNational_id; }
            set { mNational_id = value; }
        }


        [FieldFixedLength(20)]
        private String mAlternative_id;
        public String Alternative_id
        {
            get { return mAlternative_id; }
            set { mAlternative_id = value; }
        }


        [FieldFixedLength(3)]
        private String mAlternative_Id_Type;
        public String Alternative_Id_Type
        {
            get { return mAlternative_Id_Type; }
            set { mAlternative_Id_Type = value; }
        }


        [FieldFixedLength(10)]
        private String mEquity_Code;
        public String Equity_Code
        {
            get { return mEquity_Code; }
            set { mEquity_Code = value; }
        }


        [FieldFixedLength(3)]
        private String mNationality_Code;
        public String Nationality_Code
        {
            get { return mNationality_Code; }
            set { mNationality_Code = value; }
        }


        [FieldFixedLength(10)]
        private String mHome_Language_Code;
        public String Home_Language_Code
        {
            get { return mHome_Language_Code; }
            set { mHome_Language_Code = value; }
        }


        [FieldFixedLength(1)]
        private String mGender_Code;
        public String Gender_Code
        {
            get { return mGender_Code; }
            set { mGender_Code = value; }
        }


        [FieldFixedLength(10)]
        private String mCitizen_Residence_Status_Code;
        public String Citizen_Residence_Status_Code
        {
            get { return mCitizen_Residence_Status_Code; }
            set { mCitizen_Residence_Status_Code = value; }
        }


        [FieldFixedLength(2)]
        private String mSocioeconomic_Status_Code;
        public String Socioeconomic_Status_Code
        {
            get { return mSocioeconomic_Status_Code; }
            set { mSocioeconomic_Status_Code = value; }
        }


        [FieldFixedLength(10)]
        private String mDisability_Status_Code;
        public String Disability_Status_Code
        {
            get { return mDisability_Status_Code; }
            set { mDisability_Status_Code = value; }
        }


        [FieldFixedLength(45)]
        private String mLast_Name;
        public String Last_Name
        {
            get { return mLast_Name; }
            set { mLast_Name = value; }
        }


        [FieldFixedLength(26)]
        private String mFirst_Name;
        public String First_Name
        {
            get { return mFirst_Name; }
            set { mFirst_Name = value; }
        }


        [FieldFixedLength(50)]
        private String mMiddle_Name;
        public String Middle_Name
        {
            get { return mMiddle_Name; }
            set { mMiddle_Name = value; }
        }


        [FieldFixedLength(10)]
        private String mTitle;

        public String Title
        {
            get { return mTitle; }
            set { mTitle = value; }
        }


        [FieldFixedLength(8)]
        private String mBirth_Date;

        public String Birth_Date
        {
            get { return mBirth_Date; }
            set { mBirth_Date = value; }
        }


        [FieldFixedLength(50)]
        private String mHome_Address_1;

        public String Home_Address_1
        {
            get { return mHome_Address_1; }
            set { mHome_Address_1 = value; }
        }


        [FieldFixedLength(50)]
        private String mHome_Address_2;

        public String Home_Address_2
        {
            get { return mHome_Address_2; }
            set { mHome_Address_2 = value; }
        }


        [FieldFixedLength(50)]
        private String mHome_Address_3;

        public String Home_Address_3
        {
            get { return mHome_Address_3; }
            set { mHome_Address_3 = value; }
        }


        [FieldFixedLength(50)]
        private String mPostal_Address_1;

        public String Postal_Address_1
        {
            get { return mPostal_Address_1; }
            set { mPostal_Address_1 = value; }
        }


        [FieldFixedLength(50)]
        private String mPostal_Address_2;

        public String Postal_Address_2
        {
            get { return mPostal_Address_2; }
            set { mPostal_Address_2 = value; }
        }


        [FieldFixedLength(50)]
        private String mPostal_Address_3;

        public String Postal_Address_3
        {
            get { return mPostal_Address_3; }
            set { mPostal_Address_3 = value; }
        }


        [FieldFixedLength(4)]
        private String mHome_Address_Postal_Code;

        public String Home_Address_Postal_Code
        {
            get { return mHome_Address_Postal_Code; }
            set { mHome_Address_Postal_Code = value; }
        }


        [FieldFixedLength(4)]
        private String mPostal_Addr_Postal_Code;

        public String Postal_Addr_Postal_Code
        {
            get { return mPostal_Addr_Postal_Code; }
            set { mPostal_Addr_Postal_Code = value; }
        }


        [FieldFixedLength(20)]
        private String mPhone_Number;
        public String Person_phone_number
        {
            get { return mPhone_Number; }
            set { mPhone_Number = value; }
        }


        [FieldFixedLength(20)]
        private String mCellphone;
        public String Cellphone_number
        {
            get { return mCellphone; }
            set { mCellphone = value; }
        }


        [FieldFixedLength(20)]
        private String mFax;

        public String Fax_number
        {
            get { return mFax; }
            set { mFax = value; }
        }


        [FieldFixedLength(50)]
        private String memail;

        public String email_address
        {
            get { return memail; }
            set { memail = value; }
        }


        [FieldFixedLength(2)]
        private String mProvince_Code;

        public String Province_Code
        {
            get { return mProvince_Code; }
            set { mProvince_Code = value; }
        }


        [FieldFixedLength(20)]
        private String mProvider_Code;

        public String Provider_Code
        {
            get { return mProvider_Code; }
            set { mProvider_Code = value; }
        }


        [FieldFixedLength(10)]
        private String mprovider_etqa_Id;
        public String provider_etqa_id
        {
            get { return mprovider_etqa_Id; }
            set { mprovider_etqa_Id = value; }
        }


        [FieldFixedLength(45)]
        private String mPrevious_Lastname;
        public String Previous_Lastname
        {
            get { return mPrevious_Lastname; }
            set { mPrevious_Lastname = value; }
        }

        [FieldFixedLength(20)]
        private String mPrevious_Alternative_Id;
        public String Previous_Alternative_Id
        {
            get { return mPrevious_Alternative_Id; }
            set { mPrevious_Alternative_Id = value; }
        }

        [FieldFixedLength(3)]
        private String mPrevious_Alternative_Id_Type;
        public String Previous_Alternative_Id_Type
        {
            get { return mPrevious_Alternative_Id_Type; }
            set { mPrevious_Alternative_Id_Type = value; }
        }


        [FieldFixedLength(20)]
        private String mPrevious_Provider_code;
        public String Previous_Provider_code
        {
            get { return mPrevious_Provider_code; }
            set { mPrevious_Provider_code = value; }
        }


        [FieldFixedLength(10)]
        private String mPrevious_Provider_Etqa_Id;
        public String Previous_Provider_Etqa_Id
        {
            get { return mPrevious_Provider_Etqa_Id; }
            set { mPrevious_Provider_Etqa_Id = value; }
        }


        [FieldFixedLength(2)]
        private String mSeeing_Rating_Id;
        public String Seeing_Rating_Id
        {
            get { return mSeeing_Rating_Id; }
            set { mSeeing_Rating_Id = value; }
        }


        [FieldFixedLength(2)]
        private String mHearing_Rating_Id;
        public String Hearing_Rating_Id
        {
            get { return mHearing_Rating_Id; }
            set { mHearing_Rating_Id = value; }
        }


        [FieldFixedLength(2)]
        private String mCommunicating_Rating_Id;
        public String Communication_Rating_Id
        {
            get { return mCommunicating_Rating_Id; }
            set { mCommunicating_Rating_Id = value; }
        }


        [FieldFixedLength(2)]
        private String mWalking_Rating_Id;
        public String Walking_Rating_Id
        {
            get { return mWalking_Rating_Id; }
            set { mWalking_Rating_Id = value; }
        }


        [FieldFixedLength(2)]
        private String mRemembering_Rating_Id;

        public String Remembering_Rating_Id
        {
            get { return mRemembering_Rating_Id; }
            set { mRemembering_Rating_Id = value; }
        }


        [FieldFixedLength(2)]
        private String mSelfcare_Rating_Id;

        public String Selfcare_Rating_Id
        {
            get { return mSelfcare_Rating_Id; }
            set { mSelfcare_Rating_Id = value; }
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
