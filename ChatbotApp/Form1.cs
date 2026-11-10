namespace ChatbotApp
{
    public partial class Form1 : Form
    {
        private ChatEngine engine = new ChatEngine();
        public Form1()
        {
            InitializeComponent();
            ChatInput.AppendText("Bot: Greetings! I am your Cybersecurity Assistant." +
                " How can I help you today?" +
                " Also, may I ask what your name is?"
                + Environment.NewLine + Environment.NewLine);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Step 8 (Page 13): The button click
            string reply = engine.GetResponse(ChatInput2.Text);

            ChatInput.AppendText("You: " + ChatInput2.Text + Environment.NewLine);
            ChatInput.AppendText("Bot: " + reply + Environment.NewLine + Environment.NewLine);

            ChatInput2.Clear();

        }
    }
}
