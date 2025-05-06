public class JogoDaForca
{
    // Listas para armazenar os bonequinhos completos por dificuldade
    private List<string> bonecoFacil;
    private List<string> bonecoMedio;
    private List<string> bonecoDificil;

    public JogoDaForca()
    {
        // Inicializa os bonequinhos completos para cada dificuldade
        InicializarBonequinhos();
    }

    private void InicializarBonequinhos()
    {
        // Bonequinho para "Fácil"
        bonecoFacil = new List<string>
        {
            "   O  ",       // Cabeça
            "   |  ",       // Corpo
            "  /|  ",       // Braços parciais
            "  /|\\ ",      // Braços completos
            "  /   ",       // Pernas parciais
            "  / \\ ",      // Pernas completas
            "  /'\\ "       // Morte (completo)
        };

        // Bonequinho para "Médio"
        bonecoMedio = new List<string>
        {
            "   O  ",       // Cabeça
            "   |  ",       // Corpo
            "  /|  ",       // Braços parciais
            "  /|\\ ",      // Braços completos
            "  /",          // Pernas parciais
            "  / \\ ",      // Pernas completas
            "  / \\ x"      // Morte (completo)
        };

        // Bonequinho para "Difícil"
        bonecoDificil = new List<string>
        {
            "   O  ",       // Cabeça
            "   |  ",       // Corpo
            "  /|\\ ",      // Braços completos
            "  / \\ "       // Pernas completas
        };
    }

    public void bonequinho(string dif, int tent)
    {
        // Calcula o número de erros
        int totalTent = dif switch
        {
            "Fácil" => 7,
            "Médio" => 5,
            "Difícil" => 3,
            _ => throw new ArgumentException("Dificuldade inválida")
        };

        int erros = totalTent - tent;

        // Escolhe a lista correta com base na dificuldade
        List<string> boneco = dif switch
        {
            "Fácil" => bonecoFacil,
            "Médio" => bonecoMedio,
            "Difícil" => bonecoDificil,
            _ => throw new ArgumentException("Dificuldade inválida")
        };

        // Exibe as partes do boneco até o número de erros
        for (int i = 0; i < erros; i++)
        {
            Console.WriteLine(boneco[i]);
        }
    }
}
