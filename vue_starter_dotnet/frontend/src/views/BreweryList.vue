<template>
  <div class="base">
    <div class="breweryList">
    <h1>Brewery List</h1>
    
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
  font-weight: bolder;
  background-color: whitesmoke;
  border-radius: 35%;
 padding: 20px;
  padding-bottom: 50px;
  text-align: center;
  width: 40%;
  margin-left: 30%;
  margin-right: 15%;
  overflow-y:auto;
  padding: 50px;
}
.brewlist{
  margin: auto;
}
.base{
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
  background-image: url('../assets/1.jpg');
  overflow-y:auto;
   padding: 50px
}
</style>