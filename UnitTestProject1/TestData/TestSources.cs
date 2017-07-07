using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.TestData
{
    class TestSources
    {
        public static IEnumerable<String> Name()
        {
            String[] names = TestData.CreditCardDetails.firstName.Split(',');

            foreach (string name in names)
            {
                yield return name;

            }
        }

        public static IEnumerable<String> LastName()
        {
            String[] lastNames = TestData.CreditCardDetails.lastName.Split(',');

            foreach (string lastName in lastNames)
            {
                yield return lastName;

            }
        }

        public static IEnumerable<String> Company()
        {
            String[] companies = TestData.CreditCardDetails.company.Split(',');

            foreach (string company in companies)
            {
                yield return company;

            }
        }

        public static IEnumerable<String> Email()
        {
            String[] emails = TestData.CreditCardDetails.email.Split(',');

            foreach (string email in emails)
            {
                yield return email;

            }
        }

        public static IEnumerable<String> Country()
        {
            String[] countries = TestData.CreditCardDetails.country.Split(',');

            foreach (string country in countries)
            {
                yield return country;

            }
        }

        public static IEnumerable<String> City()
        {
            String[] cities = TestData.CreditCardDetails.city.Split(',');

            foreach (string city in cities)
            {
                yield return city;

            }
        }

        public static IEnumerable<String> StreetAddress()
        {
            String[] streetAddresses = TestData.CreditCardDetails.streetAddress.Split(',');

            foreach (string streetAddress in streetAddresses)
            {
                yield return streetAddress;

            }
        }

        public static IEnumerable<String> ZipCode()
        {
            String[] zipCodes = TestData.CreditCardDetails.zipCode.Split(',');

            foreach (string zipCode in zipCodes)
            {
                yield return zipCode;

            }
        }

        public static IEnumerable<String> PhoneNumber()
        {
            String[] phoneNumbers = TestData.CreditCardDetails.phoneNumber.Split(',');

            foreach (string phoneNumber in phoneNumbers)
            {
                yield return phoneNumber;

            }
        }

        public static IEnumerable<String> CardType()
        {
            String[] cardTypes = TestData.CreditCardDetails.cardType.Split(',');

            foreach (string cardType in cardTypes)
            {
                yield return cardType;

            }
        }

        public static IEnumerable<String> ExpirationMonth()
        {
            String[] expirationMonths = TestData.CreditCardDetails.expirationMonth.Split(',');

            foreach (string expirationMonth in expirationMonths)
            {
                yield return expirationMonth;

            }
        }

        public static IEnumerable<String> ExpirationYear()
        {
            String[] expirationYears = TestData.CreditCardDetails.expirationYear.Split(',');

            foreach (string expirationYear in expirationYears)
            {
                yield return expirationYear;

            }
        }

        public static IEnumerable<String> CVV()
        {
            String[] CVVS = TestData.CreditCardDetails.CVV.Split(',');

            foreach (string CVV in CVVS)
            {
                yield return CVV;

            }
        }

        public static IEnumerable<String> CardNumber()
        {
            String[] cardNumbers = TestData.CreditCardDetails.cardNumber.Split(',');

            foreach (string cardNumber in cardNumbers)
            {
                yield return cardNumber;

            }
        }

        public static IEnumerable<String> GoogleLogin()
        {
            String[] googleLogins = TestData.Accounts.googleLogin.Split(',');

            foreach (string googleLogin in googleLogins)
            {
                yield return googleLogin;

            }
        }

        public static IEnumerable<String> ExchangeServiceLogin()
        {
            String[] exchangeLogins = TestData.Accounts.exchangeServiceLogin.Split(',');

            foreach (string exchangeLogin in exchangeLogins)
            {
                yield return exchangeLogin;

            }
        }

        public static IEnumerable<String> iCloudServiceLogin()
        {
            String[] iCloudLogins = TestData.Accounts.iCloudServiceLogin.Split(',');

            foreach (string iCloudLogin in iCloudLogins)
            {
                yield return iCloudLogin;

            }
        }

        public static IEnumerable<String> GooglePass()
        {
            String[] googlepasses = TestData.Accounts.googlePass.Split(',');

            foreach (string googlePass in googlepasses)
            {
                yield return googlePass;

            }
        }

        public static IEnumerable<String> ExchangeServicePass()
        {
            String[] exchangePasses = TestData.Accounts.exchangeServicePass.Split(',');

            foreach (string exchangePass in exchangePasses)
            {
                yield return exchangePass;

            }
        }

        public static IEnumerable<String> iCloudServicePass()
        {
            String[] iCloudGooglePasses = TestData.Accounts.iCloudServicePass.Split(',');

            foreach (string iCloudGooglePass in iCloudGooglePasses)
            {
                yield return iCloudGooglePass;

            }
        }

        public static IEnumerable<String> GoogleServiceLogin()
        {
            String[] googleServiceLogins = TestData.Accounts.googleServiceLogin.Split(',');

            foreach (string googleServiceLogin in googleServiceLogins)
            {
                yield return googleServiceLogin;

            }
        }

        public static IEnumerable<String> GoogleServicePass()
        {
            String[] googleServicePasses = TestData.Accounts.googleServicePass.Split(',');

            foreach (string googleServicePass in googleServicePasses)
            {
                yield return googleServicePass;

            }
        }

        public static IEnumerable<String> GoogleSignUpLogin()
        {
            String[] googleSignUpAccounts = TestData.Accounts.googleSignUpAccount.Split(',');

            foreach (string googleSignUpAccount in googleSignUpAccounts)
            {
                yield return googleSignUpAccount;

            }
        }

        public static IEnumerable<String> GoogleSignUpPass()
        {
            String[] googleSignUpPasswords = TestData.Accounts.googleSignUpPassword.Split(',');

            foreach (string googleSignUpPassword in googleSignUpPasswords)
            {
                yield return googleSignUpPassword;

            }
        }

    }
}
