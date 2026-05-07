//Sturm Savage
//RCET2265
//Spring Semester 2026
//https://github.com/savastur/CarRental.git
/*
 * [x] Create a validation for all text boxes
 * [x] Ensure that the days text box can't be less than 0 or greater than 45
 * [x] Remove any invalid data and message the user that it's invalid
 * [x] Beginnig odometer must be > ending odometer reading
 * [x] Do not permit any calcuations unless all inputs are valid
 * [] Enable the summary button only after the calculation button has been clicked
 * [] Claculate the distance driven the fisrt 200 miles are free
 * [] If miles is > 200, charge $0.12 per mile
 * [] If miles is > 500, charge $0.10 per mile
 * [] Determine if the distance driven is in miles or kilometers, all calulations should be in miles. 1 kilometer = 0.62miles
 * [] Check to see if the AAA or Senior discount are selected, Senior get a 3% and AAA get a 5% discount.
*/
namespace CarRental
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Default();
        }
        private void Default()
        {
            nameBox.Text = "";
            addressBox.Text = "";
            cityBox.Text = "";
            stateBox.Text = "";
            zipCodebox.Text = "";
            beginingOdometerbox.Text = "";
            endingOdometerBox.Text = "";
            daysDrivenbox.Text = "";
            claculateButton.Enabled = false;
            summeryButton.Enabled = false;
        }
        void Verify()
        {
            //name verification
            if (nameBox.Text.Length == 0)
            {
                nameBox.BackColor = Color.LightYellow;
            }
            else
            {
                nameBox.BackColor = Color.White;
            }
            //address verification
            if (addressBox.Text.Length == 0)
            {
                addressBox.BackColor = Color.LightYellow;
            }
            else
            {
                addressBox.BackColor = Color.White;
            }
            //city verification
            if (cityBox.Text.Length == 0)
            {
                cityBox.BackColor = Color.LightYellow;
            }
            else
            {
                cityBox.BackColor = Color.White;
            }
            //zip code verification
            if (zipCodebox.Text.Length == 0 || !NumberVerification(zipCodebox.Text))
            {
                zipCodebox.BackColor = Color.LightYellow;
            }
            else
            {
                zipCodebox.BackColor = Color.White;
            }
            //state verification
            if (stateBox.Text.Length == 0)
            {
                stateBox.BackColor = Color.LightYellow;
            }
            else
            {
                stateBox.BackColor = Color.White;
            }
            //odometer verification
            try
            {
                int endingOdometer = Int32.Parse(endingOdometerBox.Text);
                int beginingOdometer = Int32.Parse(beginingOdometerbox.Text);
                if (endingOdometer < beginingOdometer)
                {
                    MessageBox.Show("Ending odometer must be greater than beginning odometer.\n Final reading first before the begining reading.");
                    endingOdometerBox.Text = "";
                    beginingOdometerbox.Text = "";
                }
                else
                {
                    endingOdometerBox.BackColor = Color.White;
                    beginingOdometerbox.BackColor = Color.White;
                }
            }
            catch
            {
                if (beginingOdometerbox.Text.Length == 0 || endingOdometerBox.Text.Length == 0)
                {
                    endingOdometerBox.BackColor = Color.LightYellow;
                    beginingOdometerbox.BackColor = Color.LightYellow;
                }
                else
                {
                    MessageBox.Show("Odometer readings must be valid numbers");
                    endingOdometerBox.Text = "";
                    beginingOdometerbox.Text = "";
                }
            }
            //days driven verification
            if (daysDrivenbox.Text.Length == 0)
            {
                daysDrivenbox.BackColor = Color.LightYellow;
            }
            else
            {
                if (!NumberVerification(daysDrivenbox.Text))
                {
                    MessageBox.Show("Days driven must be a valid number");
                    daysDrivenbox.Text = "";
                }
                else
                {
                    int daysDriven = int.Parse(daysDrivenbox.Text);
                    if (daysDriven < 0 || daysDriven > 45)
                    {
                        MessageBox.Show("Days driven must be between 0 and 45");
                        daysDrivenbox.Text = "";
                    }
                    else
                    {
                        daysDrivenbox.BackColor = Color.White;
                    }
                }
            }
            // Enable buttons if all inputs are valid
            try
            {
                int endingOdometer = Int32.Parse(endingOdometerBox.Text);
                int beginingOdometer = Int32.Parse(beginingOdometerbox.Text);
                int daysDriven = int.Parse(daysDrivenbox.Text);
                // All .Lengths verify that text boxes are filled.
                if (nameBox.Text.Length != 0 && addressBox.Text.Length != 0 && cityBox.Text.Length != 0 && stateBox.Text.Length != 0 && zipCodebox.Text.Length != 0 && endingOdometer >= beginingOdometer && daysDriven >= 0 && daysDriven <= 45)
                {
                    claculateButton.Enabled = true;
                }
                else
                {
                    claculateButton.Enabled = false;
                }

            }
            catch
            {
                claculateButton.Enabled = false;
                summeryButton.Enabled = false;
            }
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            Verify();
        }
        private bool NumberVerification(string number)
        {
            try
            {
                int.Parse(number);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void zipCodebox_TextChanged(object sender, EventArgs e)
        {
            Verify();
        }

        private void addressBox_TextChanged(object sender, EventArgs e)
        {
            Verify();
        }

        private void cityBox_TextChanged(object sender, EventArgs e)
        {
            Verify();
        }

        private void stateBox_TextChanged(object sender, EventArgs e)
        {
            Verify();
        }

        private void beginingOdometerbox_TextChanged(object sender, EventArgs e)
        {
            Verify();
        }

        private void endingOdometerBox_TextChanged(object sender, EventArgs e)
        {
            Verify();
        }

        private void daysDrivenbox_TextChanged(object sender, EventArgs e)
        {
            Verify();
        }
        // Converts kilometers to miles using the conversion factor 1 kilometer = 0.62 miles
        private double KilometersToMiles(double kilometers)
        {
            return kilometers * 0.62;
        }

        private void claculateButton_Click(object sender, EventArgs e)
        {
            int endingOdometer = Int32.Parse(endingOdometerBox.Text);
            int beginingOdometer = Int32.Parse(beginingOdometerbox.Text);
            // Verify's if the kilometers is selected 
            if (kilometerButton.Checked)
            {
                // Gives total miles by converting the difference of odometer readings from kilometers.
                double miles = KilometersToMiles(endingOdometer - beginingOdometer);
                // Converts to int for simplicity in calculations
                Calculations(Convert.ToInt32(miles)); // Sends distance driven in miles
            }
            if (milesButton.Checked)
            {
                int miles = endingOdometer - beginingOdometer;
                Calculations(miles); // Sends distance driven in miles
            }
            
        }
        // Calculates Cost of distance driven, days driven, and discounts if applicable.
        private void Calculations(int milesDriven)
        {

        }
    }

}
