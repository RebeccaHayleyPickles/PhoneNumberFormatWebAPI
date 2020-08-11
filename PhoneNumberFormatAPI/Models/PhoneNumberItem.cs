using System;
using System.Text.RegularExpressions;
public class PhoneNumberItem
{
    public long Id { get; set; }
    private string E164number;
    private string CountryCode = "+44";
    private string[] E164Pattern = { 
                    "^19756[0-9]+$", "^19467[0-9]+$", "^19755[0-9]+$", "^17687[0-9]+$", "^17684[0-9]+$", "^17683[0-9]+$", 
                    "^16977[0-9]+$", "^16974[0-9]+$", "^16973[0-9]+$", "^15396[0-9]+$", "^15395[0-9]+$", "^15394[0-9]+$",
                    "^15242[0-9]+$", "^13873[0-9]+$", "^13398[0-9]+$", "^13397[0-9]+$", "^1[0-9]1[0-9]+$", "^11[0-9]+$", 
                    "^1[0-9]+$", "^2[0-9]+$", "^3[0-9]+$", "^5[0-9]+$", "^7[0-9]+$", "^800[0-9]+$", "^8[0-9]+$", "^9[0-9]+$"
    }; 

    private string[] humanPattern = {
                    "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}",
                    "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}",
                    "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0### ### ####}", "{0:0### ### ####}",
                    "{0:0#### ######}","{0:0## #### ####}", "{0:0### ### ####}", "{0:0#### ######}", "{0:0#### ######}", "{0:0### ######}", "{0:0### ### ####}",
                    "{0:0### ### ####}"
    };

    public string PhoneNumber { 
        get{
            string tempNumber = E164number.Replace(CountryCode, "");
            bool _match = false;

            for(int i = 0; i < E164Pattern.Length; i++){
                _match = Regex.IsMatch(tempNumber, E164Pattern[i]);

                if (_match){
                    tempNumber = String.Format(humanPattern[i], Convert.ToInt64(tempNumber));
                    break;
                }
            }
            return tempNumber;
        } 
        set{
            E164number = value;
        } 
    }
}
