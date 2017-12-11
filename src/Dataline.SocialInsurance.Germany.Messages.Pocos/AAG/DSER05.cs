﻿// <copyright file="DSER05.cs" company="DATALINE GmbH &amp; Co. KG">
// Copyright (c) DATALINE GmbH &amp; Co. KG. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;

using NodaTime;

namespace SocialInsurance.Germany.Messages.Pocos.AAG
{
    /// <summary>
    /// Datensatz: DSER - Erstattungen der Arbeitgeberaufwendungen
    /// </summary>
    public class DSER05 : IDatensatz
    {
        private bool? _hatDbau;

        private bool? _hatDbbt;

        private bool? _hatDbzu;

        private bool? _hatDbbv;

        private bool? _hatDbna;

        private bool? _hatDbaa;

        private bool? _fekz;

        /// <summary>
        /// Holt oder setzt die Kennung
        /// </summary>
        /// <remarks>
        /// Kennung, um welchen Datensatz es sich handelt
        /// </remarks>
        public string KE { get; set; } = "DSER";

        /// <summary>
        /// Holt oder setzt das Verfahren
        /// </summary>
        /// <remarks>
        /// Verfahren, für das der Datensatz bestimmt ist, Länge 5, Mussangabe
        /// DEUEV = DEÜV- Meldeverfahren
        /// </remarks>
        public string VF { get; set; } = Info.DSER.Verfahren;

        /// <summary>
        /// Holt oder setzt die Betriebsnummer des Erstellers des Datensatzes
        /// </summary>
        /// <remarks>
        ///  Betriebsnummer des Erstellers des Datensatzes, Länge 15, (8 Stellen linksbündig mit nachfolgenden Leerzeichen), Mussangabe
        /// </remarks>
        public string BBNRAB { get; set; }

        /// <summary>
        /// Holt oder setzt die Betriebsnummer des Empfängers des Datensatzes
        /// </summary>
        /// <remarks>
        /// Betriebsnummer des Empfängers des Datensatzes, Länge 15, (8 Stellen linksbündig mit nachfolgenden Leerzeichen), Mussangabe
        /// </remarks>
        public string BBNREP { get; set; }

        /// <summary>
        /// Holt oder setzt die Versionsnummer des übermittelten Datensatzes
        /// </summary>
        /// <remarks>
        /// Versionsnummer des übermittelten Datensatzes, Länge 2, Mussangabe
        /// </remarks>
        public int VERNR { get; set; } = 5;

        /// <summary>
        /// Holt oder setzt den Zeitpunkt der Erstellung des Dateznsatzes
        /// </summary>
        /// <remarks>
        /// Zeitpunkt der Erstellung des Datensatzes, Länge 20, jhjjmmtt (Datum) hhmmss (Uhrzeit) msmsms (Mikrosekunde) (Wert > 0 in letzten 6 Stellen optional), Mussangabe
        /// </remarks>
        public DateTime ED { get; set; }

        /// <summary>
        /// Holt oder setzt die Kennzeichnung für fehlerhafte Datensätze
        /// </summary>
        /// <remarks>
        /// Kennzeichnung für fehlerhafte Datensätze, Länge 1, 0 = Datensatz fehlerfrei 1 = Datensatz fehlerhaft, Mussangabe
        /// </remarks>
        public bool FEKZ
        {
            get => _fekz ?? DBFE != null && DBFE.Count != 0;
            set => _fekz = value;
        }

        /// <summary>
        /// Holt die Anzahl der Fehler des Datensatzes
        /// </summary>
        /// <remarks>
        /// Anzahl der Fehler des Datensatzes, Länge 1, Mussangabe
        /// </remarks>
        public int FEAN
        {
            get { return DBFE?.Count ?? 0; }
            private set { }
        }

        /// <summary>
        /// Holt oder setzt die Versicherungsnummer
        /// </summary>
        /// <remarks>
        /// Versicherungsnummer in der Form: bbttmmjjassp, Länge 12, Pflichtangabe, soweit bekannt
        /// </remarks>
        public string VSNR { get; set; }

        /// <summary>
        /// Holt oder setzt das Geburtsdatum des Versicherten im Format
        /// </summary>
        /// <remarks>
        /// Geburtsdatum des Versicherten , Länge 8, Mussangabe
        /// </remarks>
        public LocalDate GEBDA { get; set; }

        /// <summary>
        /// Holt oder setzt die Betriebsnummer des Verursachers des Datensatzes
        /// </summary>
        /// <remarks>
        /// Betriebsnummer des Verursachers des Datensatzes, Länge 15, Mussangabe
        /// Bei der Datenübermittlung zwischen dem Arbeitgeber und der Krankenkasse
        /// ist hier die Betriebsnummer des Beschäftigungsbetriebes anzugeben.
        /// </remarks>
        public string BBNRVU { get; set; }

        /// <summary>
        /// Holt oder setzt das dem Verursacher zur Verfügung stehende Feld
        /// </summary>
        /// <remarks>
        /// Dieses Feld steht dem Verursacher zur Verfügung, Länge 20, Kannangabe
        /// Bei der Datenübermittlung zwischen dem Arbeitgeber und der Krankenkasse:
        /// z. B. Aktenzeichen / Personalnummer des Beschäftigten
        /// </remarks>
        public string AZVU { get; set; }

        /// <summary>
        /// Holt oder setzt die Betriebsnummer der für den Beschäftigten zuständigen Krankenkasse
        /// </summary>
        /// <remarks>
        /// Betriebsnummer der für den Beschäftigten zuständigen Krankenkasse, Länge 15, Mussangabe
        /// </remarks>
        public string BBNRKK { get; set; }

        /// <summary>
        /// Holt oder setzt das der Krankenkasse zur Verfügung stehende Feld
        /// </summary>
        /// <remarks>
        /// Dieses Feld steht der Krankenkasse zur Verfügung, Länge 20, Pflichtangabe, soweit bekannt
        /// </remarks>
        public string AZKK { get; set; }

        /// <summary>
        /// Holt oder setzt die Betriebsnummer der Abrechnungsstelle
        /// </summary>
        /// <remarks>
        /// Betriebsnummer der Abrechnungsstelle, z. B. Steuerberater, Länge 15, Pflichtangabe, soweit bekannt
        /// 8 Stellen linksbündig mit nachfolgenden Leerzeichen
        /// </remarks>
        public string BBNRAS { get; set; }

        /// <summary>
        /// Holt oder setzt den Grund der Abgabe
        /// </summary>
        /// <remarks>
        /// Grund der Abgabe, Länge 2, Mussangabe
        /// 01 = bei Arbeitsunfähigkeit, 02 = bei Beschäftigungsverbot nach dem MuSchG
        /// 03 = bei Mutterschaft
        /// </remarks>
        public int GD { get; set; }

        /// <summary>
        /// Holt oder setzt den Beschäftigungsbeginn
        /// </summary>
        /// <remarks>
        /// Beschäftigungsbeginn in der Form: jhjjmmtt, Länge 8, Mussangabe
        /// </remarks>
        public LocalDate BESCHSEIT { get; set; }

        /// <summary>
        /// Holt oder setzt die Art der Versicherung
        /// </summary>
        /// <remarks>
        /// Art der Versicherung, Länge 1, Mussangabe
        /// 0 = in der GKV versichert, 1 = privat versichert
        /// 2 = LKK-versichert, 3 = geringfügige Beschäftigung
        /// </remarks>
        public Versicherungsart ARTVERS { get; set; }

        /// <summary>
        /// Holt oder setzt das Geschlecht
        /// </summary>
        /// <remarks>
        /// Geschlecht, Länge 1, Mussangabe
        /// M = Männlich, W = Weiblich
        /// </remarks>
        public string GE { get; set; }

        /// <summary>
        /// Holt oder setzt die Art des verwendeten Abrechnungsprogramms
        /// </summary>
        /// <remarks>
        /// Art des verwendeten Abrechnungsprogramms, Länge 1, Mussangabe
        /// 1 = systemgeprüftes Entgeltabrechnungsprogramm
        /// 2 = systemgeprüfte Ausfüllhilfe
        /// </remarks>
        public Abrechnungsprogramm APRO { get; set; }

        /// <summary>
        /// Produkt-Identifier des geprüften Softwareproduktes, das beim Ersteller der Datei eingesetzt wird.
        /// </summary>
        /// <remarks>
        /// Sie wird von der ITSG, eindeutig für jedes systemuntersuchte Programm, vergeben.
        /// </remarks>
        public string PRODID { get; set; }

        /// <summary>
        /// Modifikations-Identifier des geprüften Softwareproduktes, das beim Ersteller der Datei eingesetzt wird.
        /// </summary>
        /// <remarks>
        /// Sie wird von der ITSG, eindeutig für jedes systemuntersuchte Programm, vergeben.
        /// </remarks>
        public string MODID { get; set; }

        /// <summary>
        /// Eindeutige Kennzeichnung des Datensatzes durch den Ersteller
        /// </summary>
        public string DSID { get; set; }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Erstattungen Arbeitgeberaufwendungen Arbeitsunfähigkeit vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBAU, Länge 1, Mussangabe
        /// Erstattungen Arbeitgeberaufwendungen Arbeitsunfähigkeit vorhanden:
        /// N = Nein, J = Ja
        /// </remarks>
        public bool MMDBAU
        {
            get => _hatDbau ?? DBAU != null;
            set => _hatDbau = value;
        }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Erstattungen Beschäftigungsverbot vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBBT, Länge 1, Mussangabe
        /// Erstattungen Beschäftigungsverbot vorhanden:
        /// N = Nein, J = Ja
        /// </remarks>
        public bool MMDBBT
        {
            get => _hatDbbt ?? DBBT != null;
            set => _hatDbbt = value;
        }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Erstattungen Mutterschaft vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBZU, Länge 1, Mussangabe
        /// Erstattungen Mutterschaft vorhanden:
        /// N = Nein, J = Ja
        /// </remarks>
        public bool MMDBZU
        {
            get => _hatDbzu ?? DBZU != null;
            set => _hatDbzu = value;
        }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Bankverbindung vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBBV, Länge 1, Mussangabe
        /// Bankverbindung vorhanden: J = Ja
        /// </remarks>
        public bool MMDBBV
        {
            get => _hatDbbv ?? DBBV != null;
            set => _hatDbbv = value;
        }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Name vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBNA, Länge 1, Mussangabe
        /// Name vorhanden: J = Ja
        /// </remarks>
        public bool MMDBNA
        {
            get => _hatDbna ?? DBNA != null;
            set => _hatDbna = value;
        }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Ansprechpartner Arbeitgeber vorhanden ist
        /// </summary>
        /// <remarks>
        /// Datenbaustein DBAA, Länge 1, Mussangabe
        /// Ansprechpartner Arbeitgeber vorhanden: N = Nein, J = Ja
        /// </remarks>
        public bool MMDBAA
        {
            get => _hatDbaa ?? DBAA != null;
            set => _hatDbaa = value;
        }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Arbeitsunfähigkeit vorhanden ist
        /// </summary>
        public DBAU05 DBAU
        {
            get => ListeDBAU?.SingleOrDefault();
            set
            {
                ListeDBAU = ListeDBAU.Set(value);
                _hatDbau = null;
            }
        }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Beschäftigungsverbot vorhanden ist
        /// </summary>
        public DBBT05 DBBT
        {
            get => ListeDBBT?.SingleOrDefault();
            set
            {
                ListeDBBT = ListeDBBT.Set(value);
                _hatDbbt = null;
            }
        }

        /// <summary>
        /// Holt oder setzt einen Wert, der angibt, ob der Datenbaustein Mutterschaft vorhanden ist
        /// </summary>
        public DBZU04 DBZU
        {
            get => ListeDBZU?.SingleOrDefault();
            set
            {
                ListeDBZU = ListeDBZU.Set(value);
                _hatDbzu = null;
            }
        }

        /// <summary>
        /// Holt oder setzt den Datenbaustein für Bankverbindung
        /// </summary>
        public DBBV DBBV
        {
            get => ListeDBBV?.SingleOrDefault();
            set
            {
                ListeDBBV = ListeDBBV.Set(value);
                _hatDbbv = null;
            }
        }

        /// <summary>
        /// Holt oder setzt den Datenbaustein für Name
        /// </summary>
        public DBNA DBNA
        {
            get => ListeDBNA?.SingleOrDefault();
            set
            {
                ListeDBNA = ListeDBNA.Set(value);
                _hatDbna = null;
            }
        }

        /// <summary>
        /// Holt oder setzt den Datenbaustein für Ansprechpartner
        /// </summary>
        public DBAA DBAA
        {
            get => ListeDBAA?.SingleOrDefault();
            set
            {
                ListeDBAA = ListeDBAA.Set(value);
                _hatDbaa = null;
            }
        }

        /// <summary>
        /// Holt oder setzt eine Liste von Fehlern
        /// </summary>
        public IList<DBFE> DBFE { get; set; }

        /// <summary>
        /// Holt die Datenbausteine eines Datensatzes
        /// </summary>
        public IEnumerable<IDatenbaustein> Datenbausteine
        {
            get
            {
                foreach (var datenbaustein in ListExtensions.Enumerate(ListeDBAU, ListeDBBT, ListeDBZU, ListeDBBV, ListeDBNA, ListeDBAA, DBFE))
                    yield return datenbaustein;
            }
        }

        private IList<DBAU05> ListeDBAU { get; set; }

        private IList<DBBT05> ListeDBBT { get; set; }

        private IList<DBZU04> ListeDBZU { get; set; }

        private IList<DBBV> ListeDBBV { get; set; }

        private IList<DBNA> ListeDBNA { get; set; }

        private IList<DBAA> ListeDBAA { get; set; }
    }
}
