namespace SemanticKernelIntro.Components;

public class Quarto
{
    public int Id { get; set; } = 0;
    public string? Numero { get; set; } = default; 
    public string Descricao { get; set; } = default!;
    public bool IsDisponivel { get; set; } = true;

    public Quarto(int id, string? numero, string descricao, bool isDisponivel)
    {
        Id = id;
        Numero = numero;
        Descricao = descricao;
        IsDisponivel = isDisponivel;
    }
}