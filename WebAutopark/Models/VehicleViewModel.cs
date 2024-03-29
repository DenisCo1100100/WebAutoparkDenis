﻿using System.ComponentModel.DataAnnotations;
using WebAutopark.BusinessLogic.DataTransferObject;

namespace WebAutopark.Models
{
    public class VehicleViewModel
    {
        private const double WeightCoefficient = 0.0013d;
        private const double TaxCoefficient = 30d;
        private const double TaxPerMonthAddition = 5d;

        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int VehicleTypeId { get; set; }

        public VehicleTypeViewModel VehicleType { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Model { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string RegistrationNumber { get; set; }

        [Range(0d, int.MaxValue)] 
        public int Year { get; set; }

        [Range(0d, double.MaxValue)] 
        public double Weight { get; set; }

        [Range(0d, double.MaxValue)] 
        public double Mileage { get; set; }
        
        [Range(1d, double.MaxValue)]
        public double FuelConsumption { get; set; }

        [Range(1d, double.MaxValue)]
        public double TankCapacity { get; set; }

        [Required] 
        public ColorType Color { get; set; }

        public double GetCalcTaxPerMonth() => Weight * WeightCoefficient +
            VehicleType.TaxCoefficient * TaxCoefficient + TaxPerMonthAddition;

        public double GetCalcMaxKm() => (TankCapacity / FuelConsumption) * 100;
    }
}