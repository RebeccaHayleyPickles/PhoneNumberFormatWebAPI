using System;
using System.Text.RegularExpressions;
public class PhoneNumberItem
{
    public long Id { get; set; }
    private string E164number;
    private string countryCode = "+44";
    private string[] E164Pattern = { 
                    "^19756[0-9]{5}$", "^19467[0-9]{5}$", "^19755[0-9]{5}$", "^17687[0-9]{5}$", "^17684[0-9]{5}$", "^17683[0-9]{5}$", 
                    "^16977[0-9]{5}$", "^16977[0-9]{4}$", "^16974[0-9]{5}$", "^16973[0-9]{5}$", "^15396[0-9]{5}$", "^15395[0-9]{5}$", 
                    "^15394[0-9]{5}$", "^15242[0-9]{5}$", "^13873[0-9]{5}$", "^13398[0-9]{5}$", "^13397[0-9]{5}$", "^1[0-9]1[0-9]{7}$", 
                    "^11[0-9]{8}$", "^1[0-9]{8}$", "^1[0-9]{9}$", "^2[0-9]{9}$", "^3[0-9]{9}$", "^5[0-9]{9}$", 
                    "^7[0-9]{9}$", "^800[0-9]{6}$", "^8[0-9]{9}$", "^9[0-9]{9}$"
    }; 

    private string[] humanPattern = {
                    "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}",
                    "{0:0##### #####}", "{0:0##### ####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", 
                    "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0##### #####}", "{0:0### ### ####}", 
                    "{0:0### ### ####}","{0:0#### #####}", "{0:0#### ######}","{0:0## #### ####}", "{0:0### ### ####}", "{0:0#### ######}", 
                    "{0:0#### ######}", "{0:0### ######}", "{0:0### ### ####}", "{0:0### ### ####}"
    };

    public string PhoneNumber { 
        // GET method for phone numbers, implements formatting from E.164 to human-readable
        get{
            string tempNumber = E164number.Replace(countryCode, ""); // removes country code

            bool _match = false;
            for(int i = 0; i < E164Pattern.Length; i++){
                _match = Regex.IsMatch(tempNumber, E164Pattern[i]); // checks number order against E.164 patterns

                if (_match){
                    // changes format to UK human-readable according to whichever E.164 format it follows 
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
