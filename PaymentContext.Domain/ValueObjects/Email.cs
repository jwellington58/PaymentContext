﻿using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            Address = address;
            AddNotifications(new Contract<Email>()
                .Requires()
                .IsEmail(Address, nameof(Address), "Invalid Email")
            );
        }

        public string Address { get; set; }
    }
}
