using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.ViewModels;
using TipCalc.Core.Services;

namespace TipCalc.Core.ViewModels
{
    public class TipViewModel:MvxViewModel
    {
        ICalculationService _calculationService;

        public TipViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            subTotal = 100;
            generosity = 10;
            Recalculate();
        }

        private double subTotal;
        public double SubTotal
        {
            get => subTotal;
            set
            {
                subTotal = value;
                RaisePropertyChanged(()=>SubTotal);
                Recalculate();
            }
 
        }

        private int generosity;
        public int Generosity
        {
            get => generosity;
            set
            {
                generosity = value;
                RaisePropertyChanged(()=>Generosity);
                Recalculate();
            }
        }

        private double tip;
        public double Tip
        {
            get => tip;
            set
            {
                tip = value;
                RaisePropertyChanged(()=>Tip);
            }
        }

        private void Recalculate()
        {
            Tip = _calculationService.TipAmount(SubTotal,Generosity);
        }
    }
}
