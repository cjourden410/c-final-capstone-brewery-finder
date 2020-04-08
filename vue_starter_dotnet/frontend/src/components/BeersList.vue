<template>
    <table>
        <thead>
            <tr>
                <td>Name</td>
                <td>Type></td>
                <td>ABV</td>
            </tr>
        </thead>
        <tbody>
            <tr v-for="beer in beers" :key="beer.id">
                <td>
                    <router-link :to="{name: 'Beer', params:{id:beer.id}}">{{beer.id}}</router-link>
                </td>
                <td>{{beer.type}}</td>
                <td>{{beer.abv}}</td>
        </tbody>
    </table>
</template>
<script>
</script>