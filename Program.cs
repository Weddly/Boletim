using System;

namespace Boletim
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indexAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indexAluno] = aluno;
                        indexAluno++;

                        break;
                    case "2":
                        foreach(var a in alunos) 
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}" );
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var nrAlunos = 0;
                        for (int i=0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                            

                        }

                        var mediaGeral = notaTotal/nrAlunos;
                        EConceito conceitoGeral;

                        if (mediaGeral < 3) 
                        {
                            conceitoGeral = EConceito.E;
                        
                        }
                        else if (mediaGeral < 6) 
                        {
                            conceitoGeral = EConceito.D;
                        }
                        else if (mediaGeral < 8) 
                        {
                            conceitoGeral = EConceito.C;
                        }
                        else if (mediaGeral < 9) 
                        {
                            conceitoGeral = EConceito.B;
                        }
                        else
                        {
                            conceitoGeral = EConceito.A;
                        }

                        Console.WriteLine($"Média geral: {mediaGeral}");
                        Console.WriteLine($"Conceito geral: {conceitoGeral}");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2 - Listar alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
