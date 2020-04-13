<template>
<div>
    <h1>Ratings and Reviews</h1>
  <table>
      <thead>
          <tr>
              <td>Beer Name</td>
              <td>Beer Rating</td>
              <td>Review</td>
          </tr>
      </thead>
      <tbody>
          <tr v-for="rating in ratings" :key="rating.id">
               <td>
                    <router-link :to="{name: 'beerInfo', params:{id:rating.beerID}}">{{rating.beerName}}</router-link>
                </td>
              <td>{{rating.rating}}</td>
              <td>{{rating.review}}</td>
          </tr>
      </tbody>
  </table>
  </div>
</template>

<script>
export default {
name: "rating-list",
props:{
    ratings: Array
},
data(){
    return{};
},
methods: {},
computed: {}
};
</script>

<style>

</style>