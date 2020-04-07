<template>
  <div>
    <div class="breweryList">
    <h1>Brewery List</h1>
    <div>Welcome {{user.sub}}, {{user.rol}}</div>
    <brewery-list :breweries="breweries"></brewery-list>
  </div>
  </div>
</template>

<script>
import auth from '../auth';
import BreweryList from "@/components/BreweriesList.vue";

export default {
  name: 'breweries',
  components:{
    "brewery-list": BreweryList
  },
  data() {
    return{
      user: null,
      breweries: []
    }
  },
  methods: {
    GetBreweries(){
      let url = `${process.env.VUE_APP_REMOTE_API}/breweryList`;
    
      fetch(url)
        .then(response => {
          response.json()
            .then(json => {
              this.breweries = json;
            })
        }).catch(err => {
          console.log(err)
        });

      }
  },
  created() {
    this.user = auth.getUser();
    this.GetBreweries();
  }
}
</script>

<style>
.breweryList {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
  padding-bottom: 10px;
  text-align: center;
}
</style>