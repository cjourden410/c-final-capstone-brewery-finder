<template>
  <div class="base">
    <div class="breweryList">
    <h1>Brewery List</h1>
    <div>Welcome {{user.sub}}, {{user.rol}}</div>
    <brewery-list :breweries="breweries" class="brewlist"></brewery-list>
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
      let url = `${process.env.VUE_APP_REMOTE_API}/breweries`;
    
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

<style scoped>
.breweryList {
  background-color: whitesmoke;
  border-radius: 35%;
  margin-left: 15%;
  margin-right: 15%;
 padding: 20px;
  padding-bottom: 50px;
  text-align: center;
}
.brewlist{
  margin: auto;
}
.base{
 width: auto;
 height: 600px;
  background-image: url('../assets/1.jpg');
}
</style>