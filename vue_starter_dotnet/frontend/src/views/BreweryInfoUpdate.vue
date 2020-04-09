<template>
  <div class="BreweryInfoUpdate">
    <h1>Update Brewery Info</h1>
    <!-- <div>Welcome {{user.sub}}, {{user.rol}}</div> -->
    <form @submit.prevent="HandleChosen">
      <div>
        Brewery ID:
        <select v-model="chosenId">
          <option v-for="brewery in breweries" :key="brewery.id">{{brewery.id}}</option>
        </select>
      </div>
      <button type="submit">Edit Selected Brewery, Idk, something like that..</button>
    </form>
    <div v-if="this.isChosen">
      <form>
        <div>
          Name of Brewery:
          <input
            type="text"
            v-model="brewery.name"
            class="breweryInput"
            placeholder="Billy Bob's Shine Factory"
          />
        </div>
        <div>
          Name of Head Brewer:
          <input
            type="text"
            v-model="brewery.brewer"
            class="breweryInput"
            placeholder="Billy Bob"
          />
        </div>
        <div>
          User ID:
          <input
            type="number"
            v-model.number="brewery.userID"
            class="breweryInput"
            placeholder="123"
          />
        </div>
      </form>
    </div>

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
</template>

<script>
import BreweryInfoVue from "./BreweryInfo.vue";
// import auth from "../auth";

export default {
  name: "breweryInfoUpdate",
  props: {
    isChosen: false,
    chosenId: Number
  },
  data() {
    return {
      selectedBrewery: null,
      breweries: []
    };
  },
  methods: {
    getBrewery(id) {
      // This is the url...
      let url = `${process.env.VUE_APP_REMOTE_API}/breweries/${id}`;

      // fetch here...
      fetch(url)
        .then(responce => {
          responce.json().then(json => {
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
    },
    HandleChosen() {
      this.isChosen = !this.isChosen;
    }
  },
  created() {
    this.GetBreweries();
  }
};
</script>

<style scoped>

</style>