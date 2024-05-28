using Listas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Listas.Services
{
    public class ContactService
    {
        public async Task<List<Models.Contact>> GetContactsAsync() // Especificar el espacio de nombres completo
        {
            await Task.Delay(1000); // Simula un retardo de red.

            // Datos simulados.
            return new List<Models.Contact> // Especificar el espacio de nombres completo
            {
                new Models.Contact { Name = "John Doe", Message = "Hello there!", ProfilePictureUrl = "https://via.placeholder.com/50" },
                new Models.Contact { Name = "Jane Smith", Message = "Good morning!", ProfilePictureUrl = "https://via.placeholder.com/50" },
                new Models.Contact { Name = "Sam Brown", Message = "How are you?", ProfilePictureUrl = "https://via.placeholder.com/50" }
            };
        }
    }
}
