﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAppLexicon.Models.Members;

namespace WebAppLexicon.Models
{
    public class Skills
    {
        public Skills() { }
        [Key]
        public int ID { get; set; }
        public int SkillId { get; set; }
        public int MemberId { get; set; }
        public string SkillDesc { get; set; }
        public int SkillLevel { get; set; }
        public int SkillYears { get; set; }
        public int Charges { get; set; }
        public string ChargeUnit { get; set; } // hour/Day/trip
        public int MinUnit { get; set; }
        public SkillCats SkillCat { get; set; }
        public WebAppLexicon.Models.Members.Members Xmembers { get; set; }
    }
}
