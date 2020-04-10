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
          <rating-list :rating="rating" class="rating"></rating-list>
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
    GetRatings(breweryID) {
      let url = `${process.env.VUE_APP_REMOTE_API}/reviews?breweryID=${breweryID}`;
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
    this.GetRatings(this.$route.params.id);
    this.getBreweries();
  }
};
</script>

<style>
.viewRatings {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding: 10px;
  padding-bottom: 20px;
  text-align: center;
}
.rating {
  margin: auto;
}
.base {
  width: auto;
  height: 600px;
  background-image: url("../assets/13.jpg");
}
</style>