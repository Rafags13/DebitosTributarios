namespace DebitosTributarios.Domain.Helpers
{
    public class ValidateCpfCnpjHelper
    {
        public static bool ValidarCpfCnpj(string valor)
        {
            var digits = new string(valor.Where(char.IsDigit).ToArray());

            return digits.Length switch
            {
                11 => ValidarCpf(digits),
                14 => ValidarCnpj(digits),
                _ => false
            };
        }

        public static bool ValidarCpf(string cpfCnpj)
        {
            if (string.IsNullOrWhiteSpace(cpfCnpj))
                return false;

            var cpf = new string(cpfCnpj.Where(char.IsDigit).ToArray());

            if (cpf.Length != 11)
                return false;

            if (cpf.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCpf = cpf.Substring(0, 9);
            var soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;
            var digito = resto < 2 ? 0 : 11 - resto;

            tempCpf += digito;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            digito = resto < 2 ? 0 : 11 - resto;

            var cpfValido = tempCpf + digito;

            return cpf.EndsWith(cpfValido[^2..]);
        }

        public static bool ValidarCnpj(string cpfCnpj)
        {
            if (string.IsNullOrWhiteSpace(cpfCnpj))
                return false;

            var cnpj = new string(cpfCnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                return false;

            if (cnpj.Distinct().Count() == 1)
                return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            var tempCnpj = cnpj.Substring(0, 12);
            var soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            var resto = soma % 11;
            var digito = resto < 2 ? 0 : 11 - resto;

            tempCnpj += digito;

            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            digito = resto < 2 ? 0 : 11 - resto;

            var cnpjValido = tempCnpj + digito;

            return cnpj.EndsWith(cnpjValido[^2..]);
        }
    }
}
