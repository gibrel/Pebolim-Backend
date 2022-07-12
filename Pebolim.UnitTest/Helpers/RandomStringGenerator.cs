using System.Security.Cryptography;
using System.Text;

namespace Pebolim.UnitTest.Helpers
{
    public static class RandomStringGenerator
    {
        private static readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string Generate(int length = 8)
        {
            StringBuilder randomStringBuilder = new();

            for (int i = 0; i < length; i++)
            {
                randomStringBuilder.Append(chars[RandomNumberGenerator.GetInt32(chars.Length)]);
            }

            return randomStringBuilder.ToString();
        }

        private static readonly string[] sylabes = new string[] {
            "a","i","u","e","o",
            "ab","ib","ub","eb","ob",       "ac","ic","uc","ec","oc",
            "ad","id","ud","ed","od",       "af","if","uf","ef","of",
            "ag","ig","ug","eg","og",       "ah","ih","uh","eh","oh",
            "aj","ij","uj","ej","oj",       "ak","ik","uk","ek","ok",
            "al","il","ul","el","ol",       "am","im","um","em","om",
            "an","in","un","en","on",       "ap","ip","up","ep","op",
            "aq","iq","uq","eq","oq",       "ar","ir","ur","er","or",
            "as","is","us","es","os",       "at","it","ut","et","ot",
            "av","iv","uv","ev","ov",       "aw","iw","uw","ew","ow",
            "ax","ix","ux","ex","ox",       "ay","iy","uy","ey","oy",
            "az","iz","uz","ez","oz",

            "ba","bi","bu","be","bo",       "bra","bri","bru","bre","bro",
            "bla","bli","blu","ble","blo",

            "ca","ci","cu","ce","co",       "cha","chi","chu","che","cho",
            "cla","cli","clu","cle","clo",  "cra","cri","cru","cre","cro",

            "da","di","du","de","do",       "dla","dli","dlu","dle","dlo",
            "dra","dri","dru","dre","dro",

            "fa","fi","fu","fe","fo",       "fla","fli","flu","fle","flo",
            "fra","fri","fru","fre","fro",

            "ga","gi","gu","ge","go",       "gla","gli","glu","gle","glo",
            "gra","gri","gru","gre","gro",

            "ha","hi","hu","he","ho",

            "ja","ji","ju","je","jo",

            "ka","ki","ku","ke","ko",       "kla","kli","klu","kle","klo",
            "kra","kri","kru","kre","kro",

            "la","li","lu","le","lo",       "lha","lhi","lhu","lhe","lho",

            "ma","mi","mu","me","mo",

            "na","ni","nu","ne","no",       "nha","nhi","nhu","nhe","nho",

            "pa","pi","pu","pe","po",       "pha","phi","phu","phe","pho",
            "pla","pli","plu","ple","plo",  "pra","pri","pru","pre","pro",

            "qua","qui","que","quo",

            "ra","ri","ru","re","ro",

            "sa","si","su","se","so",       "sha","shi","shu","she","sho",
            "sla","sli","slu","sle","slo",

            "ta","ti","tu","te","to",       "tha","thi","thu","the","tho",
            "tla","tli","tlu","tle","tlo",  "tra","tri","tru","tre","tro",
            "tsa","tsi","tsu","tse","tso",

            "va","vi","vu","ve","vo",       "vla","vli","vlu","vle","vlo",
            "vra","vri","vru","vre","vro",

            "xa", "xi", "xu", "xe", "xo",

            "wa","wi","wu","we","wo",       "wha","whi","whu","whe","who",

            "ya","yi","yu","ye","yo",

            "za","zi","zu","ze","zo"
        };

        public static string GenerateName(int minNumberOfLetters = 6, int maxNumberOfLetters = 0, bool firstUppercase = false)
        {
            StringBuilder nameStringBuilder = new();

            do
            {
                nameStringBuilder.Append(sylabes[RandomNumberGenerator.GetInt32(sylabes.Length)]);
            }
            while (nameStringBuilder.Length < minNumberOfLetters
                    && ((maxNumberOfLetters > nameStringBuilder.Length + 3) || CoinFlip()));

            var name = nameStringBuilder.ToString();

            if (firstUppercase)
            {
                string firstLetter = name[..1];
                name = name.Remove(0, 1);
                firstLetter = firstLetter.ToUpper();
                name = firstLetter + name;
            }

            return name;
        }

        public static bool CoinFlip()
        {
            if (RandomNumberGenerator.GetInt32(2) == 0) return false;
            return true;

        }

    }

}
