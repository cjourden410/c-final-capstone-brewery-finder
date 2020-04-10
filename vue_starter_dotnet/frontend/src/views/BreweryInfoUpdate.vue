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
              v-model="selectedBrewery.hours"
              class="breweryInput"
            />
          </div>
          <div>
            Contact Information:
            <input
              type="text"
              v-model="selectedBrewery.contactInfo"
              class="breweryInput"
            />
          </div>
          <div>
            Address:
            <input
              type="text"
              v-model="selectedBrewery.address"
              class="breweryInput"
            />
          </div>
          <div>
            History:
            <textarea
              type="text"
              v-model="selectedBrewery.history"
              class="breweryInput history"
            />
          </div>
          <div>
            Brewery Images:
            <input
              type="text"
              v-model="selectedBrewery.images"
              class="breweryInput"
            />
          </div>
          <div>
            Active/Inactive:
            <input
              type="text"
              v-model="selectedBrewery.isActive"
              class="breweryInput"
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