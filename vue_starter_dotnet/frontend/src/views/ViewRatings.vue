<template>
  <div class="base">
      <div class ="viewRatings">
      <h1>Veiw Beer Ratings</h1>
      <rating-list :rating="rating" class="rating"></rating-list>
      </div>
  </div>
</template>

<script>
import RatingsList from "@/components/RatingsList.vue";
export default {
name: 'rating',
components:{
    "rating-list": RatingsList
},
data(){
    return{
        ratings:[]
    }
},
methods:{
    GetRatings(breweryID){
    let url =`${process.env.VUE_APP_REMOTE_API}/beers?breweryID=${breweryID}`;
    fetch(url)
    .then(response => {
        response.json()
        .then(json => {
            this.ratings = json
        })
    }).catch(err => {
        console.log(err)
    });
    }
},
created(){
    this.GetRatings(this.$route.params.id);
}
}

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
.rating{
    margin: auto;
}
.base{
  width: auto;
  height: 600px;
  background-image: url('../assets/13.jpg');
}
</style>