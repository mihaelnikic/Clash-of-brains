using Android.Graphics;
using Android.Widget;
using RankingForms.ImplIgre.Answers;

namespace RankingForms.ImplIgre
{
    public class Question
    {
        public int IdPitanja { get; }
        public string TextPitanja { get; }
        public string SlikaPitanja { get; }
        public Answer Odgovor { get; }
        public Kategorija Kategorija { get; }
        public string OpisKategorije { get; }

        public Question(int idPitanja, string textPitanja, string slikaPitanja, Answer odgovor, Kategorija kategorija, string opisKategorije)
        {
            IdPitanja = idPitanja;
            TextPitanja = textPitanja;
            SlikaPitanja = slikaPitanja;
            Odgovor = odgovor;
            Kategorija = kategorija;
            OpisKategorije = opisKategorije;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Question)) return false;
            Question q = (Question) obj;

            return IdPitanja.Equals(q.IdPitanja);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public System.Type GetAnswerType()
        {
            return Odgovor.Type;
        }

        public Kategorija GetKategorija()
        {
            return this.Kategorija;
        }

        
    }
}