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
    }
  },
  saveBrewery() {
    // TODO 05: use fetch to Update the city on the server (PUT)
    let url = `${process.env.VUE_APP_REMOTE_API}/breweries/${this.selectedBrewery.id}`;

    // fetch here...
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
  padding: 10px;
  padding-bottom: 20px;
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