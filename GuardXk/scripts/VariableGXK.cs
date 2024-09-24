namespace GuardXk.Security{
    public class VariableGXK {
        public byte[] bytes;
        public VariableGXK(){
            bytes = new byte[]{};
            GXK.Values.Enqueue(this);
        }

        public void Dispose(){
            bytes = new byte[]{};
        }
    }
}