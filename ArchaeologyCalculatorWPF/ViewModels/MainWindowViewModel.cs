using ArchaeologyCalculatorWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchaeologyCalculatorWPF.ViewModels
{
    public class MainWindowViewModel
    {
        public Artifact? Artifact { get; set; }

        public MainWindowViewModel() 
        {
            Artifact = new();
        }

        public void ComputeResults(double invSpace)
        {
            StringBuilder sb = new();

            var art = Artifact!;

            sb.AppendLine($"To restore {art.QuantityOwned} {art.Name}, you will need:");

            foreach (var artMaterial in art.Materials!)
            {
                var amountTotal = art.QuantityOwned * artMaterial.AmountNeeded;
                var amountNeeded = amountTotal - artMaterial.AmountOwned;

                sb.AppendLine(amountNeeded > 0 ? $"A total of {amountTotal} {artMaterial.Name}. You own {artMaterial.AmountOwned} so gather {amountNeeded} ({CalculateInventories(amountNeeded, invSpace)} inventories)."
                    : $"A total of {amountTotal} {artMaterial.Name}. You own {artMaterial.AmountOwned} so you dont need to gather any.");
            }

            Artifact!.Results = sb.ToString();
        }

        private int CalculateInventories(int amountNeeded, double invSpace)
        {
            int roundedInvSpace = (int)Math.Round(invSpace, MidpointRounding.ToEven);
            return (int)Math.Ceiling((decimal)amountNeeded / roundedInvSpace);
        }

        public void ClearScreen()
        {
            Artifact!.Name = string.Empty;
            Artifact!.QuantityOwned = 0;
            Artifact!.Materials = new();

            Artifact!.Results = string.Empty;
        }
    }
}
