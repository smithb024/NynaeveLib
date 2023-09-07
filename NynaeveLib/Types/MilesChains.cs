namespace NynaeveLib.Types
{
    using System;
    using NynaeveLib.ViewModel;

    public class MilesChains : ViewModelBase
    {
        private int miles = 0;
        private int chains = 0;

        /// <summary>
        /// Initialises a new instance of the <see cref="MilesChains"/> class.
        /// </summary>
        /// <param name="inputMiles">new distance (miles)</param>
        /// <param name="inputChains">new distance (chains)</param>
        public MilesChains(int inputMiles, int inputChains)
        {
            miles = inputMiles;
            chains = inputChains;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="MilesChains"/> class.
        /// </summary>
        /// <param name="inputMilesChains">distance input</param>
        public MilesChains(string inputMilesChains)
        {
            Update(inputMilesChains);
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="MilesChains"/> class.
        /// </summary>
        public MilesChains()
          : this(0, 0)
        {
        }

        /// <summary>
        /// Gets or sets the miles.
        /// </summary>
        public int Miles
        {
            get => miles;

            set
            {
                miles = value;
                this.OnPropertyChanged(nameof(this.Miles));
            }
        }

        /// <summary>
        /// Gets or sets the miles.
        /// </summary>
        public int Chains
        {
            get => chains;

            set
            {
                chains = value;
                this.OnPropertyChanged(nameof(this.Chains));
            }
        }

        /// <summary>
        /// Add miles and chains, if chains role over to the next mile
        /// increase miles by one and reset chains. 
        /// </summary>
        /// <param name="lhs">distance to add (left)</param>
        /// <param name="rhs">distance to add (right)</param>
        /// <returns>new distance</returns>
        public static MilesChains operator +(MilesChains lhs,
                                             MilesChains rhs)
        {
            int productMiles = lhs.Miles + rhs.Miles;
            int productChains = lhs.Chains + rhs.Chains;

            if (productChains >= 80)
            {
                ++productMiles;
                productChains = productChains - 80;
            }

            return new MilesChains(productMiles, productChains);
        }

        /// <summary>
        /// Add miles and chains, if chains role over to the next mile
        /// increase miles by one and reset chains. 
        /// </summary>
        /// <param name="lhs">distance to add (left)</param>
        /// <param name="rhs">distance to add (right)</param>
        /// <returns>new distance</returns>
        public static MilesChains operator -(MilesChains lhs,
                                             MilesChains rhs)
        {
            if (rhs.Miles > lhs.Miles ||
              (rhs.Miles == lhs.Miles && rhs.Chains > lhs.Chains))
            {
                return new MilesChains();
            }
            else
            {
                if (lhs.Chains < rhs.Chains)
                {
                    return new MilesChains(
                      lhs.Miles - rhs.Miles - 1,
                      lhs.Chains - rhs.Chains + 80);
                }

                return new MilesChains(
                  lhs.Miles - rhs.Miles,
                  lhs.Chains - rhs.Chains);
            }
        }

        /// <summary>
        /// Updates the distance
        /// </summary>
        /// <param name="inputMiles">new miles</param>
        /// <param name="inputChains">new chains</param>
        public void Update(int inputMiles, int inputChains)
        {
            Miles = inputMiles;
            Chains = inputChains;
        }

        /// <summary>
        /// Updates the distance
        /// </summary>
        /// <param name="inputMiles">new miles</param>
        /// <param name="inputChains">new chains</param>
        public void Update(string inputMiles, string inputChains)
        {
            int milesInt = 0;
            int chainsInt = 0;

            int.TryParse(inputMiles, out milesInt);
            int.TryParse(inputChains, out chainsInt);

            this.Miles = milesInt;
            this.Chains = chainsInt;
        }

        /// <summary>
        /// Updates the distance
        /// </summary>
        /// <param name="milesChains">new distance</param>
        /// <returns>success flag</returns>
        public void Update(string milesChains)
        {
            string[] cells = milesChains.Split('-');

            if (cells.Length == 2)
            {
                Update(cells[0], cells[1]);
            }
            else
            {
                throw new ArgumentOutOfRangeException(
                  "Invalid distance provided {0}",
                  milesChains);
            }
        }

        /// <summary>
        /// Return string of format "mm-cc"
        /// </summary>
        /// <returns>new string</returns>
        public override string ToString()
        {
            return miles.ToString() +
                   "-" +
                   chains.ToString("00");
        }
    }
}