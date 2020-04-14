<template>
  <div class="base">
    <div class="viewRatings">
      <h1>View Beer Ratings</h1>
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
          <button v-on:click.prevent="GetRatings()">See Reviews</button>
        </div>
        <div>
          <rating-list :ratings="ratings" class="rating"></rating-list>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import RatingsList from "@/components/RatingsList.vue";
export default {
  name: "rating",
  components: {
    "rating-list": RatingsList
  },
  data() {
    return {
      ratings: [],
      selectedBrewery: null,
      breweries: [],
      chosenId: Number
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

    GetRatings() {
      let url = `${process.env.VUE_APP_REMOTE_API}/reviews/brewery/${this.selectedBrewery.id}`;
      fetch(url)
        .then(response => {
          response.json().then(json => {
            this.ratings = json;
          });
        })
        .catch(err => {
          console.log(err);
        });
    }
  },
  created() {
    this.user = this.$attrs.user;
    // this.GetRatings(this.$route.params.id);
    this.GetBreweries();
  }
};
</script>

<style>
.viewRatings {
  background-color: whitesmoke;
  border-radius: 35%;
  width: 40%;
  margin-left: 30%;
  margin-right: 15%;
  margin-left: 30%;
  padding: 20px;
  padding-bottom: 50px;
  text-align: center;
  overflow-y:auto;
}
.rating {
  margin: auto;
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
  background-image: url("../assets/13.jpg");
  background-attachment: fixed;
  overflow-y:auto;
}
.rating {
  padding: 50px;
}
button{
  border: 1px solid black;
  border-radius: 12px;
  
}
</style>