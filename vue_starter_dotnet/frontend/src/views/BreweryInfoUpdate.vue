<template>
  <div class="base">
    <div class="BreweryInfoUpdate">
      <h1>Update Brewery Info</h1>
      <!-- <div>Welcome {{user.sub}}, {{user.rol}}</div> -->
      <form @submit.prevent="HandleChosen">
        <div>
          Brewery Name:
          <select @change="getBrewery(chosenId)" v-model="chosenId">
            <option
              v-for="brewery in breweries"
              :key="brewery.id"
              v-bind:value="brewery.id"
            >{{brewery.name}}</option>
          </select>
        </div>

        <div v-if="selectedBrewery" class="infoList">
          <div>
            Days/Hours of Operation:
            <input
              type="text"
              v-model="selectedBrewery.Hours"
              class="breweryInput"
              placeholder="Mon-Thurs 1200 - 0200 Sat 1000 - 0300, Sun Closed"
            />
          </div>
          <div>
            Contact Information:
            <input
              type="text"
              v-model="selectedBrewery.Contact"
              class="breweryInput"
              placeholder="123 456 7890"
            />
          </div>
          <div>
            Address:
            <input
              type="text"
              v-model="selectedBrewery.Address"
              class="breweryInput"
              placeholder="123 Main St, Cleveland, OH, 44111"
            />
          </div>
          <div>
            History:
            <textarea
              type="text"
              v-model="selectedBrewery.History"
              class="breweryInput history"
              placeholder="Billy Bob founded this brewery back during The Great Prohibition, makin' shine out back with his cousin LayRee. The outlaw life is the only life they've every known. Runnin' shine in the backwoods of Tennessee on the run from the law since they were 15. They'd be real disappointed to see this here today where people completely unrelated to him and his cousin using their name to turn on profit all LEGALLY at that.."
            />
          </div>
          <div>
            Brewery Images:
            <input
              type="text"
              v-model="selectedBrewery.Images"
              class="breweryInput"
              placeholder="http://WEBSITE.com/IMGNAME.jpg"
            />
          </div>
          <div>
            Active/Inactive:
            <input
              type="text"
              v-model="selectedBrewery.Active"
              class="breweryInput"
              placeholder="Active/Inactive"
            />
          </div>

          <button type="submit">Edit Selected Brewery</button>
        </div>
      </form>

      <!-- <div>
        Role:
        <select style="width: 30%" type="text" v-model="user.role" class="userInput">
          <users-list :users="users" class="userlist"></users-list>
          <option value="User">Beer Lover</option>
          <option value="Brewer">Brewer</option>
        </select>
      </div>-->
      <!-- <button v-on:click="register">Submit</button>
      </form>-->
    </div>
  </div>
</template>

<script>
// import BreweryInfoVue from "./BreweryInfo.vue";
// import auth from "../auth";

export default {
  name: "breweryInfoUpdate",
  props: {},
  data() {
    return {
      selectedBrewery: null,
      breweries: [],
      chosenId: Number,
      access: false,
      user: Object
    };
  },
  methods: {
    getBrewery(id) {
      // This is the url...
      let url = `${process.env.VUE_APP_REMOTE_API}/breweries/${id}`;

      // fetch here...
      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.selectedBrewery = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    },
    GetBreweries() {
      let url = `${process.env.VUE_APP_REMOTE_API}/breweries`;

      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.breweries = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    }
    // HandleChosen() {
    //   this.isChosen = !this.isChosen;
    // }
  },
  created() {
    this.user = this.$attrs.user;
    this.GetBreweries();
  }
};
</script>

<style scoped>
.BreweryInfoUpdate {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding-bottom: 10px;
  text-align: center;
}
.base {
  width: auto;
  height: 600px;
  background-image: url("../assets/8.jpg");
}
.infoList {
  align-content: right;
}
.history {
  width: 15%;
  height: 75px;
}
</style>