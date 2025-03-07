public class Solution {
    public string AddBinary(string a, string b) {

        int dec1 = 0, dec2 = 0, j = 0, digito, soma;

        for(int i = a.Length - 1; i >= 0; i--) {
            digito = a[i] - '0';
            dec1 += digito * ((int)Math.Pow(2, j));
            j++;
        }
        
        j = 0;

        for(int i = b.Length - 1; i >= 0; i--) {
            digito = b[i] - '0';
            dec2 += digito * ((int)Math.Pow(2, j));
            j++;
        }

        soma = dec1 + dec2;
        string bin = "";

        while (soma > 0) {
            int resto = soma % 2;
            bin = resto + bin;
            soma /= 2; 
        }

        return bin;
    }
}
