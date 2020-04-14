<template>
  <div class="base">
    <div class="BreweryInfoUpdate">
      <h1>Update Brewery Info</h1>
      <form>
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
            <input type="text" v-model="selectedBrewery.address" class="breweryInput" />
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
            <input type="text" v-model="selectedBrewery.images" class="breweryInput" />
          </div>
          <div>
            Active/Inactive:
            <input
              type="text"
              v-model="selectedBrewery.isActive"
              class="breweryInput"
            />
          </div>
          <button v-on:click="saveBrewery">Edit Selected Brewery</button>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
// import auth from "../auth";

export default {
  name: "breweryInfoUpdate",
  props: {},
  data() {
    return {
      selectedBrewery: null,
      breweries: [],
      chosenId: Number,
      user: Object
    };
  },
  methods: {
    getBrewery(id) {
      let url = `${process.env.VUE_APP_REMOTE_API}/breweries/${id}`;

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
    },
    saveBrewery() {
      let url = `${process.env.VUE_APP_REMOTE_API}/breweries/${this.selectedBrewery.id}`;

      fetch(url, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json"
        },
        body: JSON.stringify(this.selectedBrewery)
      }).then(response => {
        if (response.ok) {
          alert("Brewery has been updated!");
        } else {
          alert(
            `There was an error updating: ${response.status}: ${response.statusText}`
          );
        }
      });
    }
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
  width: 40%;
  margin-left: 30%;
  margin-right: 15%;
  padding: 20px;
  padding-bottom: 50px;
  text-align: center;
  overflow-y:auto;
  padding: 50px;
}
.base {
  width: 100vw;
  height: 100vh;
  background-size: cover;
  overflow: hidden;
  position: fixed; 
  top: 1; 
  left: 0;
  background-attachment: fixed;
  min-width: 100%;
  min-height: 100%;
  background-image: url("../assets/8.jpg");
  overflow-y:auto;
}
.infoList {
  align-content: right;
}
.history {
  width: 50%;
  height: 75px;
}
.textarea{
  size:50px;
}
</style>