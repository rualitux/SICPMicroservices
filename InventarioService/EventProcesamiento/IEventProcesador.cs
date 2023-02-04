namespace InventarioService.EventProcesamiento
{
    public interface IEventProcesador
    {
        void ProcessEvent(string message);
    }
}
