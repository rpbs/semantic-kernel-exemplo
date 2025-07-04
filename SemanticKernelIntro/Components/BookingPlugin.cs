using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SemanticKernelIntro.Components;

public class BookingPlugin
{

    public List<Quarto> quartos = [new (1, "101", "Com ar condicionado e sol da tarde", true),
                                   new (2, "102", "Com vista pro mar e sol da manhã", true),
                                   new (3, "103", "Cama para solteiro e frigobar", true),
                                   new (4, "104", "Quarto para casal com uma suite", true)];
    
    [KernelFunction("mostrar_todos_quartos"), Description("Exibir todos os quartos disponíveis")]
    public IEnumerable<Quarto> MostrarTodosQuartos() => 
        quartos.Where(x => x.IsDisponivel);

    [KernelFunction("reservar_quarto"), Description("Reservar um quarto")]
    public void Rerservar(string numero)
    {
        quartos.FirstOrDefault(x => x.Numero == numero)!.IsDisponivel = false;
    } 
    
    [KernelFunction("cancelar_reserva"), Description("Cancelar reserva de um quarto")]
    public void Cancelar([Description("Número do quarto")] string numero)
    {
        quartos.FirstOrDefault(x => x.Numero == numero)!.IsDisponivel = true;
    }     
}